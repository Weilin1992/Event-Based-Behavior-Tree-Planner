using UnityEngine;
using System.Collections;
using BT;
public class SmartObjecttest : SmartObject {

	WorldManager manager;
	// Use this for initialization
	void Start () {
		init();
		manager = WorldManager.getInstance();
		manager.register_sm(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
