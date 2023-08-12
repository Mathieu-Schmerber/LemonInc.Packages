using System;
using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.Utilities.Extensions;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace LemonInc.Editor.Utilities.Ui.Graph
{
	/// <summary>
	/// Graph view.
	/// </summary>
	/// <seealso cref="UnityEditor.Experimental.GraphView.GraphView" />
	public abstract class GraphView<TContainer, TNodeView, TNodeData> : UnityEditor.Experimental.GraphView.GraphView, IGraphView<TNodeData>
		where TContainer : INodeContainer<TNodeData>
		where TNodeView : Node, INodeView<TNodeData>, new()
		where TNodeData : ScriptableObject, INode
	{
		private TContainer _container;
		private GraphViewSearchWindowBase _searchWindow;
		private Vector2 _localMousePosition;

		private TNodeView[] _copyNodeCache;

		protected TContainer Container => _container;

		/// <summary>
		/// Gets or sets the on node created.
		/// </summary>
		/// <value>
		/// The on node created.
		/// </value>
		public Action<TNodeView> OnNodeCreatedCallback { get; set; }

		/// <summary>
		/// Gets or sets the on node selected.
		/// </summary>
		/// <value>
		/// The on node selected.
		/// </value>
		public Action<TNodeView> OnNodeSelectedCallback { get; set; }

		/// <summary>
		/// Gets or sets the on node un selected.
		/// </summary>
		/// <value>
		/// The on node un selected.
		/// </value>
		public Action<TNodeView> OnNodeUnSelectedCallback { get; set; }

		/// <summary>
		/// Gets or sets the on node created.
		/// </summary>
		/// <value>
		/// The on node created.
		/// </value>
		public Action<EdgeView> OnEdgeSelectedCallback { get; set; }

		/// <summary>
		/// Gets or sets the on node selected.
		/// </summary>
		/// <value>
		/// The on node selected.
		/// </value>
		public Action<EdgeView> OnEdgeUnSelectedCallback { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GraphView"/> class.
		/// </summary>
		protected GraphView()
	    {
		    Insert(0, new GridBackground());
		    AddManipulators();

		    serializeGraphElements += HandleCopyCutOperation;
			canPasteSerializedData += AllowPaste;
		    unserializeAndPaste += HandlePasteDuplicateOperation;
	    }

		/// <summary>
		/// Handles the copy cut operation.
		/// </summary>
		/// <param name="elements">The elements.</param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		private string HandleCopyCutOperation(IEnumerable<GraphElement> elements)
		{
			_copyNodeCache = elements.Where(x => x is TNodeView).Cast<TNodeView>().ToArray();
			return string.Empty;
		}

		/// <summary>
		/// Handles the paste duplicate operation.
		/// </summary>
		/// <param name="operationName">Name of the operation.</param>
		/// <param name="data">The data.</param>
		private void HandlePasteDuplicateOperation(string operationName, string data)
		{
			if (!AllowPaste(data))
				return;

			var totalX = 0f;
			var totalY = 0f;
			foreach (var node in _copyNodeCache)
			{
				totalX += node.GetPosition().center.x;
				totalY += node.GetPosition().center.y;
			}

			var created = new List<TNodeData>();
			var center = new Vector2(totalX / _copyNodeCache.Length, totalY / _copyNodeCache.Length);
			foreach (var node in _copyNodeCache)
			{
				var dataCopy = DuplicateNodeData(node.Data);
				if (dataCopy == null)
					continue;

				dataCopy.Position = _localMousePosition + (dataCopy.Position - center);
				Container.AddNode(dataCopy);
				AddNodeToGraph(dataCopy);
				created.Add(dataCopy);
			}

			LinkNodeViews(created);
		}
		
		/// <summary>
		/// Allows the paste.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		private bool AllowPaste(string data) => !_copyNodeCache.IsNullOrEmpty<TNodeView>();

		/// <summary>
		/// Adds the mini map.
		/// </summary>
		protected void AddMiniMap()
		{
			var miniMap = new MiniMap();

			miniMap.SetPosition(new Rect(15, 0, 200, 100));
			Add(miniMap);
		}

		/// <summary>
		/// Adds the mini map.
		/// </summary>
		/// <typeparam name="TMiniMap">The type of the mini map.</typeparam>
		protected void AddMiniMap<TMiniMap>(Action<TMiniMap> initialize) 
			where TMiniMap : MiniMap, new()
		{
			var map = new TMiniMap();

			Add(map);
			initialize?.Invoke(map);
		}

		/// <summary>
		/// Adds the search window.
		/// </summary>
		/// <param name="includeParentType">if set to <c>true</c> [include parent type].</param>
		protected void AddSearchWindow(bool includeParentType = true) => AddSearchWindow<GraphViewSearchWindow>((window) =>
		{
			var types = TypeCache.GetTypesDerivedFrom<TNodeData>().ToList();
			if (includeParentType)
				types.Insert(0, typeof(TNodeData));

			window.Initialize(types, (type) => CreateNewNode(type, GetMousePosition(_localMousePosition)));
		});

		/// <summary>
		/// Adds the search window.
		/// </summary>
		/// <typeparam name="TWindow">The type of the window.</typeparam>
		/// <param name="initialize">The initialize.</param>
		protected void AddSearchWindow<TWindow>(Action<TWindow> initialize)
			where TWindow : GraphViewSearchWindowBase
		{
			if (_searchWindow == null)
			{
				var window = ScriptableObject.CreateInstance<TWindow>();
				initialize?.Invoke(window);

				_searchWindow = window;
			}

			nodeCreationRequest = context => SearchWindow.Open(new SearchWindowContext(context.screenMousePosition), _searchWindow);
		}

		/// <summary>
		/// Adds the manipulators.
		/// </summary>
		private void AddManipulators()
		{
			RegisterCallback<MouseMoveEvent>(evt => { _localMousePosition = evt.localMousePosition; });

			this.AddManipulator(new ContentZoomer());
			this.AddManipulator(new ContentDragger());
			this.AddManipulator(new SelectionDragger());
			this.AddManipulator(new RectangleSelector());
		}

		/// <summary>
		/// Adds the style.
		/// </summary>
		/// <param name="styleSheet">The style.</param>
		public void AddStyle(StyleSheet styleSheet)
	    {
			if (styleSheet != null)
				styleSheets.Add(styleSheet);
		}

		/// <summary>
		/// Gets the node view.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <returns></returns>
		protected TNodeView GetNodeView(TNodeData data)
			=> GetNodeByGuid(data.Id) as TNodeView;

		/// <summary>
		/// Gets the node view.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		protected TNodeView GetNodeView(string id)
			=> GetNodeByGuid(id) as TNodeView;

		/// <summary>
		/// Populates the graph.
		/// </summary>
		/// <param name="container">The node container.</param>
		public void PopulateGraph(TContainer container)
		{
			_container = container;

			graphViewChanged -= OnGraphViewChanged;
			DeleteElements(graphElements);
			graphViewChanged += OnGraphViewChanged;

			var data = _container.GetAllNodes().ToList();
			data.ForEach(AddNodeToGraph);

			LinkNodeViews(data);
		}

		/// <summary>
		/// Links the nodes.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		private void LinkNodeViews(List<TNodeData> data)
		{
			foreach (var nodeData in data)
			{
				var view = GetNodeView(nodeData);
				var children = Container.GetChildren(nodeData)
					.Select(GetNodeView)
					.Cast<NodeViewBase<TNodeData>>()
					.ToList();
				
				var createdEdges = view.LinkPorts(children);
				createdEdges.ForEach(edge =>
				{
					edge.OnEdgeSelected = _ => OnEdgeSelectedCallback?.Invoke(edge);
					edge.OnEdgeUnSelected = _ => OnEdgeUnSelectedCallback?.Invoke(edge); 
					AddElement(edge);
				});
			}
		}

		/// <summary>
		/// Called when [graph view changed].
		/// </summary>
		/// <param name="changes">The changes.</param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		private GraphViewChange OnGraphViewChanged(GraphViewChange changes)
		{
			if (!changes.elementsToRemove.IsNullOrEmpty<GraphElement>())
			{
				changes.elementsToRemove.ForEach(e =>
				{
					switch (e)
					{
						case TNodeView view:
							Container.DeleteNode(view.Data);
							OnNodeDeleted(view);
							break;
						case Edge edge:
						{
							if (edge.output.node is TNodeView outputNode && edge.input.node is TNodeView inputNode)
								Container.UnlinkNodes(inputNode.Data, outputNode.Data);
							break;
						}
					}
				});
			}

			if (!changes.edgesToCreate.IsNullOrEmpty<Edge>())
			{
				changes.edgesToCreate.ForEach(edge =>
				{
					if (edge is EdgeView edgeView)
					{
						edgeView.OnEdgeSelected = _ => OnEdgeSelectedCallback?.Invoke(edgeView);
						edgeView.OnEdgeUnSelected = _ => OnEdgeUnSelectedCallback?.Invoke(edgeView);
					}

					if (edge.output.node is TNodeView outputNode && edge.input.node is TNodeView inputNode)
						Container.LinkNodes(inputNode.Data, outputNode.Data);
				});
			}

			return changes;
		}

		/// <summary>
		/// Get all ports compatible with given port.
		/// </summary>
		/// <param name="startPort">Start port to validate against.</param>
		/// <param name="nodeAdapter">Node adapter.</param>
		/// <returns>
		/// List of compatible ports.
		/// </returns>
		public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
		{
			var result = ports.ToList();

			if (startPort.node is not TNodeView view)
				return result;
			
			result.RemoveAll(endPort => endPort.direction == startPort.direction);
			if (!view.AllowSelfLinking)
				result.RemoveAll(endPort => endPort.node == startPort.node);

			return result;
		}

		/// <summary>
		/// Creates the node.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="position">The position.</param>
		protected void CreateNewNode(Type type, Vector2 position)
		{
			var node = Container.CreateNodeOfType(type);
			node.Position = position;
			AddNodeToGraph(node);

			var view = GetNodeView(node);
			if (view != null)
				OnNodeCreated(view);
		}

		/// <summary>
		/// Adds the node.
		/// </summary>
		/// <param name="data">The data.</param>
		public void AddNodeToGraph(TNodeData data)
		{
			var nodeView = new TNodeView();

			for (var i = 0; i < styleSheets.count; i++)
				nodeView.styleSheets.Add(styleSheets[i]);

			nodeView.Bind(data);
			nodeView.OnSelectedEvent = _ => OnNodeSelectedCallback?.Invoke(nodeView);
			nodeView.OnUnSelectedEvent = _ => OnNodeUnSelectedCallback?.Invoke(nodeView);
			AddElement(nodeView);

			OnNodeCreatedCallback?.Invoke(nodeView);
			OnNodeAdded(nodeView);
		}

		#region Contract
		
		/// <summary>
		/// Called when [node created].
		/// </summary>
		/// <param name="nodeView">The node view.</param>
		protected virtual void OnNodeCreated(TNodeView nodeView) { }

		/// <summary>
		/// Called when [node added].
		/// </summary>
		/// <param name="nodeView">The node view.</param>
		protected virtual void OnNodeAdded(TNodeView nodeView) { }

		/// <summary>
		/// Called when [node added].
		/// </summary>
		/// <param name="nodeView">The node view.</param>
		protected virtual void OnNodeDeleted(TNodeView nodeView) { }

		/// <summary>
		/// Returns true if the <see cref="GraphView{TContainer,TNodeView,TNodeData}"/> implementation should handle copy/pasting.
		/// If true, implement <see cref="DuplicateNodeData"/>.
		/// </summary>
		protected abstract bool HandlesCopyPaste { get; }

		/// <summary>
		///	Duplicates node data.
		/// </summary>
		/// <param name="nodeData"></param>
		/// <returns></returns>
		protected virtual TNodeData DuplicateNodeData(TNodeData nodeData) => null;

		#endregion

		/// <summary>
		/// Gets the mouse position.
		/// </summary>
		/// <param name="localMousePosition">The local mouse position.</param>
		/// <returns></returns>
		protected Vector2 GetMousePosition(Vector2 localMousePosition) => viewTransform.matrix.inverse.MultiplyPoint(localMousePosition);

		/// <summary>
		/// Build contextual menu.
		/// </summary>
		/// <param name="evt"></param>
		public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
		{
			if (HandlesCopyPaste)
			{
				if (evt.target is Node node)
				{
					if (node.IsCopiable())
						base.BuildContextualMenu(evt);
					return;
				}
				
				base.BuildContextualMenu(evt);
			}
		}
	}
}
