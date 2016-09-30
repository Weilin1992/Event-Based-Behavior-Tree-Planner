
namespace BT{


	public class LeafInvoke:BTNode{

		private ActionDelegate action;

		public LeafInvoke(ActionDelegate action){
			this.action = action;
		}
		protected override Result Excute(){
			return action();
		}
	}
}
