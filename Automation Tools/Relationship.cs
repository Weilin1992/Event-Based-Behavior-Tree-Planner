using UnityEngine;
using System.Collections;

namespace BT{
public class Relationship {

	private string relation = "relation_Instance";
	private static Relationship instance;

	public static Relationship getInstance(){

		if(instance  == null){
			instance = new Relationship();
		}
		return instance;
	}

	public void register_relation(){

	}
}
}