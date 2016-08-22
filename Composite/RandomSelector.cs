using System;

namespace BT
{


	//select a node randomly
	public class RandomSelector:Composite
	{
		protected override void Enter ()
		{
			Random random = new Random();
			runningIndex = random.Next(0,children.Count);
		}

		protected override Result Excute ()
		{
			return children[runningIndex].Tick();
		}


	}
}