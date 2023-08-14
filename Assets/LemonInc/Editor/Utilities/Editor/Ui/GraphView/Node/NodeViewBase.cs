	using System;
	using System.Collections.Generic;
	using System.Linq;
	using LemonInc.Core.Utilities.Extensions;
	using LemonInc.Editor.Utilities.Ui.GraphView.Interfaces;
	using UnityEditor.Experimental.GraphView;
	using UnityEngine;
	using UnityEngine.UIElements;

	namespace LemonInc.Editor.Utilities.Ui.GraphView.Node
	{
		/// <summary>
		/// Node view.
		/// </summary>
		/// <typeparam name="TNodeData"></typeparam>
		/// <seealso cref="UnityEditor.Experimental.GraphView.Node" />
		public abstract class NodeViewBase<TNodeData> : UnityEditor.Experimental.GraphView.Node, INodeView<TNodeData> 
			where TNodeData : class, INode
		{
			/// <summary>
			/// Gets or sets the on selected event.
			/// </summary>
			/// <value>
			/// The on selected event.
			/// </value>
			public Action<TNodeData> OnNodeSelectedEvent { get; set; }

			/// <summary>
			/// Gets or sets the on un selected event.
			/// </summary>
			/// <value>
			/// The on un selected event.
			/// </value>
			public Action<TNodeData> OnNodeUnSelectedEvent { get; set; }

			/// <summary>
			/// Gets or sets the data.
			/// </summary>
			/// <value>
			/// The data.
			/// </value>
			public TNodeData Data { get; protected set; }

			/// <summary>
			/// Gets or sets the input ports.
			/// </summary>
			/// <value>
			/// The input ports.
			/// </value>
			public Port[] InputPorts { get; private set; }

			/// <summary>
			/// Gets or sets the output ports.
			/// </summary>
			/// <value>
			/// The output ports.
			/// </value>
			public Port[] OutputPorts { get; private set; }

			private Label _titleLabel;
			private TextField _renameField;

			/// <summary>
			/// Initializes a new instance of the <see cref="NodeViewBase{TNodeData}"/> class.
			/// </summary>
			protected NodeViewBase()
			{
				SetupRenamingOption();
			}

			/// <summary>
			/// Sets up as graph node.
			/// </summary>
			private void SetupAsGraphNode()
			{
				inputContainer.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);
				outputContainer.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);

				var titleLabel = titleContainer.Q("title-label");
				titleContainer.style.flexGrow = new StyleFloat(1);
				titleLabel.style.flexGrow = new StyleFloat(1);
				titleLabel.style.unityTextAlign = new StyleEnum<TextAnchor>(TextAnchor.MiddleCenter);
			}

			/// <summary>
			/// Binds the specified data.
			/// </summary>
			/// <typeparam name="TNodeData"></typeparam>
			/// <param name="data">The data.</param>
			public void Bind(TNodeData data)
			{
				Data = data;

				this.title = Data.Alias;
				this.viewDataKey = Data.Id.ToString();
				
				style.left = Data.Position.x;
				style.top = Data.Position.y;

				if (Type == NodeType.WITHOUT_PORTS)
					SetupAsGraphNode();

				CreateInputs();
				CreateOutputs();
				OnDataBound();
			}

			/// <summary>
			/// Links the ports.
			/// </summary>
			/// <param name="nodes">The nodes.</param>
			/// <returns>The list of edges to create.</returns>
			public abstract List<EdgeView> LinkPorts(List<NodeViewBase<TNodeData>> nodes);
			
			/// <summary>
			/// Creates the inputs.
			/// </summary>
			private void CreateInputs()
			{
				InputPorts = InstantiateInputPorts()?.ToArray();
			}
			
			/// <summary>
			/// Creates the outputs.
			/// </summary>
			private void CreateOutputs()
			{
				OutputPorts = InstantiateOutputPorts()?.ToArray();
			}
			
			/// <summary>
			/// Set node position.
			/// </summary>
			/// <param name="newPos">New position.</param>
			public override void SetPosition(Rect newPos)
			{
				base.SetPosition(newPos);

				if (Data != null)
				{
					Data.Position = newPos.position;
				}
			}

			/// <summary>
			/// Called when the GraphElement is selected.
			/// </summary>
			public override void OnSelected()
			{
				base.OnSelected();
				OnNodeSelectedEvent?.Invoke(Data);
			}

			/// <summary>
			/// Called when the GraphElement is unselected.
			/// </summary>
			public override void OnUnselected()
			{
				base.OnUnselected();
				OnNodeUnSelectedEvent?.Invoke(Data);
			}

			#region Ports & Edges

			/// <summary>
			/// Instantiates the visualElement.
			/// </summary>
			/// <param name="orientation">The orientation.</param>
			/// <param name="direction">The direction.</param>
			/// <param name="capacity">The capacity.</param>
			/// <param name="type">The type.</param>
			/// <returns></returns>
			public override Port InstantiatePort(Orientation orientation, Direction direction, Port.Capacity capacity, Type type)
			{
				Port port;
				var container = direction == Direction.Input ? inputContainer : outputContainer;

				switch (Type)
				{
					case NodeType.WITHOUT_PORTS:
						port = GraphNodePort.Create(direction, capacity);
						break;
					case NodeType.WITH_PORTS:
					default:
						port = base.InstantiatePort(orientation, direction, capacity, type);
						break;
				}
				
				container.Add(port);
				return port;
			}

			/// <summary>
			/// Connects the ports.
			/// </summary>
			/// <param name="input">The input.</param>
			/// <param name="output">The output.</param>
			protected EdgeView ConnectPorts(Port input, Port output) => this.Type switch
			{
				NodeType.WITHOUT_PORTS => input.ConnectTo<GraphNodeEdge>(output),
				_ => input.ConnectTo<EdgeView>(output)
			};

			/// <summary>
			/// Add menu items to the node contextual menu.
			/// </summary>
			/// <param name="evt">The event holding the menu to populate.</param>
			public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
			{
				base.BuildContextualMenu(evt);

				if (Type == NodeType.WITHOUT_PORTS)
					evt.menu.InsertAction(0, "Add Link", a => AddLink(evt));
			}

			/// <summary>
			/// Adds the link.
			/// </summary>
			/// <param name="evt">The evt.</param>
			private void AddLink(ContextualMenuPopulateEvent evt)
			{
				if (InputPorts.IsNullOrEmpty<Port>() || InputPorts[0] is not GraphNodePort port)
					return;

				var connector = port.EdgeConnector as GraphNodeEdgeConnector<GraphNodeEdge>;
				connector?.StartDrag(evt.localMousePosition);
			}

			#endregion

			#region Renaming

			/// <summary>
			/// Sets up the renaming option.
			/// </summary>
			private void SetupRenamingOption()
			{
				if (!IsRenamable())
					return;

				capabilities |= Capabilities.Renamable;

				titleContainer.RegisterCallback<MouseDownEvent>(MouseRename, TrickleDown.TrickleDown);

				focusable = true;
				pickingMode = PickingMode.Position;
				RegisterCallback<KeyDownEvent>(KeyboardShortcuts, TrickleDown.TrickleDown);

				_titleLabel = titleContainer.Q<Label>();
				_renameField = new TextField
				{
					name = "textField",
					isDelayed = true,
					style =
					{
						display = DisplayStyle.None
					}
				};

				_renameField.ElementAt(0).style.fontSize = _titleLabel.style.fontSize;
				_renameField.ElementAt(0).style.height = 18f; // still need to figure out how to make these values depend on the label's font size
				_renameField.style.paddingTop = 8.5f;
				_renameField.style.paddingLeft = 4f;
				_renameField.style.paddingRight = 4f;
				_renameField.style.paddingBottom = 7.5f;
				titleContainer.Insert(1, _renameField);

				var textInput = _renameField.Q(TextField.textInputUssName);
				textInput.RegisterCallback<FocusOutEvent>(EndRename);
			}

			/// <summary>
			/// Mouses rename.
			/// </summary>
			/// <param name="evt">The evt.</param>
			private void MouseRename(MouseDownEvent evt)
			{
				if (evt.clickCount == 2 && evt.button == (int)MouseButton.LeftMouse && IsRenamable())
					StartRename();
			}

			/// <summary>
			/// Keyboard shortcuts.
			/// </summary>
			/// <param name="evt">The evt.</param>
			private void KeyboardShortcuts(KeyDownEvent evt)
			{
				if (evt.keyCode == KeyCode.F2 && IsRenamable())
					StartRename();
			}

			/// <summary>
			/// Starts the rename.
			/// </summary>
			public void StartRename()
			{
				_titleLabel.style.display = DisplayStyle.None;
				_renameField.SetValueWithoutNotify(title);
				_renameField.style.display = DisplayStyle.Flex;
				_renameField.Q(TextField.textInputUssName).Focus();
				_renameField.SelectAll();
			}

			/// <summary>
			/// Ends the rename.
			/// </summary>
			/// <param name="evt">The evt.</param>
			private void EndRename(FocusOutEvent evt)
			{
				_titleLabel.style.display = DisplayStyle.Flex;
				_renameField.style.display = DisplayStyle.None;

				if (title.Equals(_renameField.text)) 
					return;

				title = _renameField.text;
				Data.Alias = title;
				OnRenamed(title);
			}

			/// <summary>
			/// Called when [renamed].
			/// </summary>
			/// <param name="newName">The new name.</param>
			protected virtual void OnRenamed(string newName) { }

			#endregion

			#region Abstract contract

			protected enum NodeType
			{
				/// <summary>
				/// A node with one to many ports that can be named and managed individually.
				/// Links are made from one input port to an output port.
				/// </summary>
				WITH_PORTS,

				/// <summary>
				/// A node without visible ports.
				/// Links are made from one node to another node.
				/// </summary>
				WITHOUT_PORTS
			}

			/// <summary>
			/// Determines if a port can connect to its owner node.
			/// </summary>
			public abstract bool AllowSelfLinking { get; }

			/// <summary>
			/// Gets the type of the node.
			/// </summary>
			/// <value>
			/// The type of the node.
			/// </value>
			protected abstract NodeType Type { get; }

			/// <summary>
			/// Called when [data bound].
			/// </summary>
			protected abstract void OnDataBound();

			/// <summary>
			/// Instantiates the input ports.
			/// </summary>
			/// <returns></returns>
			/// <exception cref="System.NotImplementedException"></exception>
			protected abstract IEnumerable<Port> InstantiateInputPorts();

			/// <summary>
			/// Instantiates the output ports.
			/// </summary>
			/// <returns></returns>
			/// <exception cref="System.NotImplementedException"></exception>
			protected abstract IEnumerable<Port> InstantiateOutputPorts();
			
			#endregion
		}
	}
