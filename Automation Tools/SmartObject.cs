using System.Collections.Generic;
using UnityEngine;

namespace BT
{
	public class SmartObject:MonoBehaviour
	{
		State states = new State();
		public Dictionary<string,Affordance> affordances = new Dictionary<string,Affordance>();
		public void set_affordance(string s, Affordance f){
			affordances[s] = f;
		}

		public void remove_affordance(string s){
			affordances.Remove(s);
		}

		public Affordance get_affordance(string s){
			return affordances[s];
		}

		public void set_state(){
		}
	}
}

