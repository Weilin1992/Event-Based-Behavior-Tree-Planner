using UnityEngine;
using System.Collections.Generic;

namespace BT{
	public class WorldManager  {
		private static WorldManager instance;
		private readonly static int role_num = 10;
		private List<List<SmartObject>> smobject =  new List<List<SmartObject>>(role_num);
		private Dictionary<string,Event> all_event = new Dictionary<string,Event>();
		private Sequence root = new Sequence();

		public static WorldManager getInstance(){
			if(instance == null){
				instance = new WorldManager();
			}
			return instance;
		}

		public void register_sm(SmartObject so){
			if(so.Index != -1){
				smobject[so.RoleID].Add(so);
				so.Index = smobject[so.RoleID].Count - 1;
			}
			else{
				Debug.Log("Already exist, don't have to reinsert");
			}
		}

		public void register_Event(Event e){
			all_event[e.Name] = e;	
		}

		private bool calculate_transition(){
			bool success = false;
			
			return success;
		}
	}
}