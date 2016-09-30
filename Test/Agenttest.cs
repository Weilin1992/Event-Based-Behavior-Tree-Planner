using UnityEngine;
using System.Collections;
using BT;

public class Agenttest : SmartObject{

	int test_var = 0;
	ActionDelegate f_action;

	Sequence test_root = new Sequence();

	// Use this for initialization
	void Start () {
		f_action = test_func_increment;
		if(this == null){
			Debug.Log("null object");
		}

		affordances.Add("test_func_increment",new Affordance(f_action,this));
		test_root.AddChild(new LoopUntilSuccess(new LeafInvoke(affordances["test_func_increment"].f),-1));
	}
	
	// Update is called once per frame
	void Update () {
		Result test_result = Result.Failed;

		if(test_result != Result.Success){
			test_result = test_root.Tick();
		}
		else{
			Debug.Log("Success");
		}
	}





	Result test_func_increment(){

		test_var+=1;
		if(test_var > 100){
			Debug.Log("Success");
			return Result.Success;
		}
		else{
			Debug.Log("Running");
			return Result.Running;
		}
	}







}
