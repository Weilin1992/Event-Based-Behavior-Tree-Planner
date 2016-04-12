namespace BT
{

	public abstract class Parallel:Composite
	{

		public Parallel(params BTNode[] children):base(children)
		{
			
		}


		protected Result[] runstatus;

		protected override void Enter ()
		{
			if (this.runstatus == null)
				this.runstatus = new Result[this.children.Count];
			for (int i = 0; i < this.runstatus.Length; i++) 
			{
				this.runstatus [i] = Result.Running;
			}
			base.Enter ();
		}

	}
}