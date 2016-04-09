namespace BT
{
	//basic class for all kinds of nodes

	public class BTNode
	{
		private string name = ""; //name of the node
		private TickState state = TickState.Ready; // state of the node
		protected virtual void Enter(){}
		protected virtual Result Excute(){
			return Result.Failed;
		}

		protected virtual void Exit () {}
		public string Name{
			get { return name == "" ? GetType ().Name : name;}
			set { name = value;}
		}

		public Result Tick()
		{
			if (state == TickState.Ready) {
				Enter ();
				state = TickState.Ticking;
			}
				
			Result result = Excute ();
			if (result != Result.Running) {
				Exit ();
				state = TickState.Ready;
			}
			return result;
		}


		//exit node manully
		public void Clear()
		{
			if (state != TickState.Ready) {
				Exit ();
				state = TickState.Ready;
			}
		}

	}




}