### INodeController<TNodeData>
> where TNodeData : ScriptableObject, [INode](INode.md)

#### Public methods

| Signature | Description |
| --------- | ----------- |
| `IEnumerable<TNodeData> GetAllNodes()` | Gets all nodes. |
| `TNodeData CreateNodeOfType(Type type)` | Creates a new node of the specified type and adds it. |
| `void Add(TNodeData node)` | Adds a node. |
| `void Delete(TNodeData node)` | Deletes a node. |
| `TNodeData Duplicate(TNodeData node)` | Duplicates the specified node. |
| `void Link(TNodeData inputNode, TNodeData outputNode)` | Links the nodes. |
| `void Unlink(TNodeData inputNode, TNodeData outputNode)` | Unlinks the nodes. |
| `IEnumerable<TNodeData> GetRelated(TNodeData node)` | Gets the related nodes of a node. |

#### Abstracts

None in this interface.