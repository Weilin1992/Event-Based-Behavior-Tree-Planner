namespace BT{

	public abstract class Decorator : BTNode
	{

		protected BTNode child;

		protected Decorator(BTNode child)
		{
			this.child = child;
		}


		protected override void Exit()
		{
			child.Clear();
		}

		public BTNode GetChild()
		{
			return child;
		}
	}



}