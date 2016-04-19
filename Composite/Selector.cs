namespace BT
{

	public class Selector: Composite
	{

		//a selector excute nodes in sequence, return success if one of 
		//its child success,return failed if all the child failed


		public Selector(params BTNode[] children): base(children)
		{
		}

		protected override Result Excute()
		{
			if(runningIndex > children.Count)
				return Result.Failed;

			Result result = children[runningIndex].Tick();

			if(result == Result.Success)
			{
				return Result.Success;
			}

			if(result == Result.Failed)
			{
				runningIndex++;
			}
			return Result.Running;
		}
	}



}