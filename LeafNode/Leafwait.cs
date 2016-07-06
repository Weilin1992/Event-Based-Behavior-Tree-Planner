using System.Collections.Generic;
using System.Diagnostics;
using System;
using UnityEngine;


namespace BT
{
	public class Leafwait:BTNode
	{

		public Leafwait(long waitTime)
		{
			this.waitTime = waitTime;
			this.stopwatch = new Stopwatch();
		}


		protected long waitTime;

		protected Stopwatch stopwatch;


		protected override void Enter ()
		{
			base.Enter();
			this.stopwatch.Start();
		}

		protected override void Exit ()
		{
			base.Exit ();
			this.stopwatch.Stop();
			this.stopwatch.Reset();
		}

		protected override Result Excute()
		{

			if(this.stopwatch.ElapsedMilliseconds > this.waitTime)
				return Result.Success;
			else
				return Result.Running;


		}





	}


}