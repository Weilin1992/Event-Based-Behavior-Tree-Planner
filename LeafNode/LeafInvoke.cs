
namespace BT{
	public delegate Result LeafAction();

	public class LeafInvoke:BTNode{

		private LeafAction action;

		public LeafInvoke(LeafAction action){
			this.action = action;
		}
		protected override Result Excute(){
			return action();
		}
	}
}
