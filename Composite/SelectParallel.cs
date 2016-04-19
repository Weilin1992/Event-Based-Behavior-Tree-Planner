namespace BT
{

	//select the first child that success, return failed if none of the child success

	public class SelectParallel : Parallel
	{

		private int nodeFailed;

		public SelectParallel(params BTNode[] children) : base(children)
		{
		}

		protected override Result Excute ()
		{
			for(int i = 0; i < children.Count; i++)
			{
				if(this.runstatus[i] == Result.Running)
				{
					Result result = children[i].Tick();
					if(result == Result.Failed){
						runstatus[i] = Result.Failed;
						nodeFailed++;
					}

					if(result == Result.Success)
					{
						return Result.Success;
					}
				}
			}

			return Result.Running;
		}
			
		protected override void Enter ()
		{
			nodeFailed = 0;
			base.Enter ();
		}





	}



}