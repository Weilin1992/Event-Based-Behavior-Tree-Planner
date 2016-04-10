using System;
using System.Linq;
using UnityEngine;

namespace BT{

	public class LoopNTimes : Decorator
	{

		protected int repeatTimes;
		protected int currentTimes = 0;

		public LoopNTimes(BTNode child, int times) : base(child)
		{
			repeatTimes = times;
		}


		protected override void Enter ()
		{
			currentTimes = 0;
		}
			
		protected override Result Excute ()
		{
			child.Tick();
			currentTimes++;
			Debug.Log(currentTimes);
			if(currentTimes == repeatTimes)
				return Result.Success;
			
			return Result.Running;
		}

		public int RepeatTimes
		{
			get {return repeatTimes;}
		}

		public int CurrentTimes
		{
			get {return currentTimes;}
		}
	}







}