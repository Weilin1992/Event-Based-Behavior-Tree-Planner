using UnityEngine;
using System.Collections;
using BT;

public class SequenceParallelTest : MonoBehaviour {


	ActionDelegate action;

	BTNode root;

	int test1 = 0;

	int test2 = 0;

	int tickTImes = 0;

	Result result = Result.Running;

	// Use this for initialization

	void Start () {

		LoopNTimes l1 = new LoopNTimes (new Action (() => test1_increment ()), 20);
		LoopNTimes l2 = new LoopNTimes (new Action (() => test2_increment ()), 20);

		root = new LoopNTimes (new SequenceParallel (l1, l2), 1);

	}
	
	// Update is called once per frame
	void Update () {
		if (result == Result.Running && tickTImes % 30 == 0) {
			result = root.Tick ();
		}
		tickTImes++;
	}


	Result test1_increment()
	{
		Debug.Log ("test increment");
		test1++; 
		Debug.Log (test1);
		if (test1 > 10) {Debug.Log (Result.Success);
			return Result.Success;

		} else 
		{
			//Debug.Log ("Running");
			return Result.Running;

		}
	}



	Result test2_increment()
	{
		Debug.Log ("test increment");
		test2++; 
		Debug.Log (test2);
		if (test2 > 10) {Debug.Log (Result.Success);
			return Result.Success;

		} else 
		{
			//Debug.Log ("Running");
			return Result.Running;

		}
	}
}

