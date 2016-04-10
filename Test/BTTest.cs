using UnityEngine;
using System.Collections;
using BT;

public class BTTest : MonoBehaviour {

	// Use this for initialization

	ActionDelegate  action;

	Sequence root;
	int test = 0;
	int i = 0;

	Result result = Result.Running;

	void Start () {



		root = new Sequence ();	
		action = ()=>test_increment();
		root.AddChild (new Action (action));
	}
	
	// Update is called once per frame
	void Update () {
		
		if(result  == Result.Running && i % 30 == 0) 
		{
			result = root.Tick ();
		}	
		i++;
	}


	Result test_increment()
	{
		Debug.Log ("test increment");
		test++; 
		if (test > 10) {Debug.Log (Result.Success);
			return Result.Success;

		} else 
		{Debug.Log ("Running");
			return Result.Running;

		}
		
	}


}
