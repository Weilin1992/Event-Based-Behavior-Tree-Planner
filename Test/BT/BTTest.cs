using UnityEngine;

using BT;

public class BTTest : MonoBehaviour {
	
	ActionDelegate  action;
	Sequence root;
	int test = 0;
	int i = 0;

	public Transform P;
	
	Result result = Result.Running;
	
	void Start () {
		root = new Sequence ();	
		action = ()=> {
		Debug.Log("Test closure");

		if(P.position.x > 10){
			return Result.Success;
		}
		else{
			return Result.Running;
			}
		};
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
		} 
		else {
			Debug.Log ("Running");
			return Result.Running;

		}
	}

	Result test_closure()
	{
		Debug.Log("Test closure");

		if(P.position.x > 10){
			return Result.Success;
		}
		else{
			return Result.Running;
		}

	}



}
