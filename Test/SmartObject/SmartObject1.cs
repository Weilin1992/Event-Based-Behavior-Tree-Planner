using UnityEngine;
using System.Collections;
using BT;
public class SmartObject1 : SmartObject {

	public int test1 = 2;
	public int test1_index;

	// Use this for initialization
	void Start () {
		group_id = 2;
		init();
		manager.register_sm(this);
		register_database();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void test1_inc(int a){
		test1+= a;
	}

	protected void update_database(){
		manager.database.SetData<int>(test1_index,test1);
	}

	protected void register_database(){
		test1_index = manager.database.addData<int>(this.name+gameobject_id.ToString() + "test1",test1);
	}
}
