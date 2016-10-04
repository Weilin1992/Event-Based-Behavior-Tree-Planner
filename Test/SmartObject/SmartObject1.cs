using UnityEngine;
using System.Collections;
using BT;
public class SmartObject1 : SmartObject {

	public int test1 = 2;


	// Use this for initialization
	void Start () {
		group_id = 2;
		init();
		manager.register_sm(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void test1_inc(int a){
		test1+= a;
	}


}
