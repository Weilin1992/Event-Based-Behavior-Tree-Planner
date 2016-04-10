﻿
using UnityEngine;
namespace BT
{
	public class Sequence : Composite
	{

		public Sequence()
		{}


		public Sequence(BTNode child):base()
		{
			base.AddChild(child);
		}

		protected override Result Excute()
		{
			if (runningIndex >= children.Count)
				return Result.Success;

			Result result = children [runningIndex].Tick ();


			if (result == Result.Failed) 
			{
				return result;
			}

			if (result == Result.Success) 
			{
				runningIndex++;
				Debug.Log (children.Count);
				return Result.Running;
				//Debug.Log (runningIndex);
			}

			return Result.Running;

		}
	}


}