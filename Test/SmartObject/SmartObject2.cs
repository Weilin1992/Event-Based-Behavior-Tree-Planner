using UnityEngine;
using System.Collections;
using BT;
public class SmartObject2 :  SmartObject{
	
	public int test2 = 3;
	public int test2_index;
	// Use this for initialization
	void Start () {
		group_id = 1;
		init();
		manager.register_sm(this);
	}

	// Update is called once per frame
	void Update () {		
	}

	public void test_2_inc(int a){
		test2 += a;
	}
	
	protected void update_database(){
		manager.database.SetData<int>(test2_index,test2);
		
	}

	protected void register_database(){
		test2_index = manager.database.addData<int>(this.name+gameobject_id.ToString() + "test2",test2);
	}
}
