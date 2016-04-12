namespace BT{

	public class SequenceParallel : Parallel
	{

		private int leftNodes = 0;

		public SequenceParallel(params BTNode[] child) : base(child)
		{
		}

		protected override void Enter ()
		{
			leftNodes = this.children.Count;
			base.Enter ();
		}

		protected override Result Excute ()
		{
			for(int i = 0; i < children.Count; i++)
			{
				if (this.runstatus[i] == Result.Running) 
				{
					Result result = children [i].Tick ();
					if (result == Result.Failed) {
						return Result.Failed;
					}
					if (result == Result.Success) {
						leftNodes--;
						if (leftNodes == 0) {
							return Result.Success;
						}
					}
					runstatus[i] = result;
				} 
			}

			return Result.Running;


		}



		
	}




}