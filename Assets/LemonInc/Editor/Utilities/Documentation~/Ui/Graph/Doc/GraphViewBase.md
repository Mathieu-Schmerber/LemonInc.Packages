### GraphViewBase<TNodeView, TNodeData>
> where TNodeView : UnityEditor.Experimental.GraphView.Node, INodeView<TNodeData>, new()
> where TNodeData : ScriptableObject, [INode](INode.md)

#### Public properties

| Name | Type | Description |
| ---- | ---- | ----------- |
| OnNodeCreatedCallback | Action\<TNodeView> | Gets or sets the callback for when a node is created. |
| OnNodeSelectedCallback | Action\<TNodeView> | Gets or sets the callback for when a node is selected. |
| OnNodeUnSelectedCallback | Action\<TNodeView> | Gets or sets the callback for when a node is unselected. |
| OnEdgeSelectedCallback | Action\<EdgeView> | Gets or sets the callback for when an edge is selected. |
| OnEdgeUnSelectedCallback | Action\<EdgeView> | Gets or sets the callback for when an edge is unselected. |

#### Public methods

| Signature | Description |
| --------- | ----------- |
| `void AddStyle(StyleSheet styleSheet)` | Adds a style sheet to the graph view. |
| `void Populate()` | Populates the graph view with nodes and edges. |
| `override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)` | Gets compatible ports for connection. |

#### Protected methods

| Signature | Description |
| --------- | ----------- |
| `void CreateNewNode(Type type, Vector2 position)` | Creates a new node of the specified type and adds it to the graph. |
| `void AddNodeToGraph(TNodeData data)` | Adds a node to the graph view. |
| `Vector2 GetMousePosition(Vector2 localMousePosition)` | Converts local mouse position to world space. |

#### Abstract contract

| Signature | Description |
| --------- | ----------- |
| `protected abstract bool HandlesCopyPaste` | Returns true if the implementation should handle copy/pasting. |
| `protected abstract INodeController<TNodeData> CreateController()` | Creates the node controller. |
| `protected virtual void OnNodeCreated(TNodeView nodeView)` | Called when a node is created. |
| `protected virtual void OnNodeAdded(TNodeView nodeView)` | Called when a node is added. |
| `protected virtual void OnNodeDeleted(TNodeView nodeView)` | Called when a node is deleted. |

#### Virtual methods

| Signature | Description |
| --------- | ----------- |
| `string HandleCopyCutOperation(IEnumerable<GraphElement> elements)` | Handles the copy/cut operation. |
| `void HandlePasteDuplicateOperation(string operationName, string data)` | Handles the paste/duplicate operation. |
| `bool AllowPaste(string data)` | Checks if paste is allowed. |
| `void AddMiniMap()` | Adds a mini map to the graph view. |
| `void AddMiniMap<TMiniMap>(Action<TMiniMap> initialize)` | Adds a customized mini map to the graph view. |
| `void AddSearchWindow(bool includeParentType = true)` | Adds a search window for creating nodes. |
| `void AddSearchWindow<TWindow>(Action<TWindow> initialize)` | Adds a search window of a specific type. |
