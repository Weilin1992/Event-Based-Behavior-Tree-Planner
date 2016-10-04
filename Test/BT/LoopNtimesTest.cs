using UnityEngine;

using BT;
public class LoopNtimesTest : MonoBehaviour {

	ActionDelegate action;

	Decorator root;

	int test;

	int tickTimes;

	Result result = Result.Running;

	// Use this for initialization
	void Start () {

		root = new LoopUntilSuccess(
			new Sequence(new Action(() => test_increment())),-1
		);

	}
	
	// Update is called once per frame
	void Update () {
		

		if(result  == Result.Running && tickTimes % 30 == 0) 
		{
			result = root.Tick ();
		}	
		tickTimes++;
	
	}



	Result test_increment()
	{
		Debug.Log ("test increment");
		test++; 
		if (test > 10) {Debug.Log (Result.Success);
			return Result.Success;

		} else 
		{
			//Debug.Log ("Running");
			return Result.Running;

		}

	}
}
