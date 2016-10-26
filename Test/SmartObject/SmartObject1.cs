using UnityEngine;
using System.Collections;
using BT;
public class SmartObject1 : SmartObject {

	public int test1 = 2;
	public int test1_index;

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void test1_inc(int a){
		test1+= a;
	}

	protected override void update_database(){
		manager.database.SetData<int>(test1_index,test1);
	}

	protected override void  register_database(){
		test1_index = manager.database.addData<int>(this.name+InstanceID.ToString() + "test1",test1);
	}

	static SmartObject1(){
		group_id  = 0;
	}
}
