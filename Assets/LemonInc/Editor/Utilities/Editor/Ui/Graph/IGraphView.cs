namespace LemonInc.Editor.Utilities.Ui.Graph
{
	public interface IGraphView<TNodeData>
		where TNodeData : class, INode
	{
		public void AddNodeToGraph(TNodeData data);
	}
}