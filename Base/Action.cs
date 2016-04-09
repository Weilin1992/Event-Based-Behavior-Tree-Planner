using System;


namespace BT{
	public delegate Result ActionDelegate();

	public class Action: BTNode
	{
		
		private ActionDelegate action;

		public Action(ActionDelegate action)
		{
			this.action = action;
		}



		protected override Result Excute ()
		{

			return action ();
		}
	}
}