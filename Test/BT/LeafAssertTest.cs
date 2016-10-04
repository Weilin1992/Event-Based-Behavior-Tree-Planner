using UnityEngine;
using BT;
using System;
public class LeafAssertTest : MonoBehaviour {

	Sequence root;
	Func<bool> assertion;
	Result result = Result.Running;
	int i = 0;
	// Use this for initialization
	void Start () {
		root = new Sequence();
		assertion = () =>{
			if(i > 400)
			{
				Debug.Log("Success");
				return true;
			}
			else {
				return false;
			}
		};
		LeafAssert asserttest = new LeafAssert(assertion);
		LoopUntilSuccess looptest = new LoopUntilSuccess(asserttest,-1);
		root.AddChild(looptest);
	}
	
	// Update is called once per frame
	void Update () {
		if(result == Result.Running && i % 30 == 0)
		{
			result = root.Tick();
			Debug.Log(i);
		}else{
			Debug.Log(result);
		}
		i++;
	}


}

