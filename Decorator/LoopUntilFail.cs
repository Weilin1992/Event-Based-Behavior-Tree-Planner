namespace BT{

	//loop the child until it return Success, but still can limit the time,or input -1 which means loop infinitly
	public class LoopUntilFail : LoopNTimes
	{

		public LoopUntilFail(BTNode child, int times) : base(child,times)
		{
		}

		protected override void Enter()
		{
			currentTimes = 0;
		}

		protected override Result Excute()
		{
			if(repeatTimes < 0)
			{
				currentTimes++;
				Result result = child.Tick();
				if(result == Result.Failed)
					return Result.Failed;
				return Result.Running;

			}
			else
			{
				if(currentTimes > repeatTimes)
				{
					return Result.Failed;
				}

				currentTimes++;
				Result result = child.Tick();
				if(result == Result.Failed)
				{
					return Result.Success;
				}
				return Result.Running;
			}
		}
	}










}