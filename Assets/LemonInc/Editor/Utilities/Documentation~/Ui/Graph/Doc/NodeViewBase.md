### NodeViewBase<TNodeData>
> where TNodeData : ScriptableObject, [INode](INode.md)

#### Public properties

| Name | Type | Description |
| ---- | ---- | ----------- |
| OnNodeSelectedEvent | Action<TNodeData> | Gets or sets the on selected event. |
| OnNodeUnSelectedEvent | Action<TNodeData> | Gets or sets the on unselected event. |
| Data | TNodeData | Gets or sets the data. |
| InputPorts | Port[] | Gets the input ports. |
| OutputPorts | Port[] | Gets the output ports. |

#### Public methods

| Signature | Description |
| --------- | ----------- |
| `void Bind(TNodeData data)` | Binds the specified data. |
| `abstract List<EdgeView> LinkPorts(List<NodeViewBase<TNodeData>> nodes)` | Links the ports. |
| `void SetPosition(Rect newPos)` | Set node position. |
| `void OnSelected()` | Called when the GraphElement is selected. |
| `void OnUnselected()` | Called when the GraphElement is unselected. |

#### Protected methods

| Signature | Description |
| --------- | ----------- |
| `void SetupAsGraphNode()` | Sets up as graph node. |
| `void CreateInputs()` | Creates the input ports. |
| `void CreateOutputs()` | Creates the output ports. |
| `EdgeView ConnectPorts(Port input, Port output)` | Connects the ports. |
| `void SetupRenamingOption()` | Sets up the renaming option. |
| `void MouseRename(MouseDownEvent evt)` | Mouses rename. |
| `void KeyboardShortcuts(KeyDownEvent evt)` | Keyboard shortcuts. |
| `void StartRename()` | Starts the rename. |
| `void EndRename(FocusOutEvent evt)` | Ends the rename. |
| `virtual void OnRenamed(string newName)` | Called when renamed. |

#### Abstract contract

| Signature | Description |
| --------- | ----------- |
| `bool AllowSelfLinking` | Determines if a port can connect to its owner node. |
| `protected abstract NodeType Type` | Gets the type of the node. |
| `protected abstract void OnDataBound()` | Called when data is bound. |
| `protected abstract IEnumerable<Port> InstantiateInputPorts()` | Instantiates the input ports. |
| `protected abstract IEnumerable<Port> InstantiateOutputPorts()` | Instantiates the output ports. |

#### Virtual methods

None in this class.
