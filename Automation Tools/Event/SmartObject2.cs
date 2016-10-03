using UnityEngine;
using System.Collections;
using BT;
public class SmartObject2 :  SmartObject{
	
	public int test2 = 3;

	// Use this for initialization
	void Start () {

		role_id = 1;
		init();
		manager.register_sm(this);
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	
}
