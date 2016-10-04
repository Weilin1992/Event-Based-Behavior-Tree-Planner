using UnityEngine;
using System.Collections.Generic;

namespace BT{
	public class WorldManager  {
		private static WorldManager instance;
		private readonly static int group_count = 10;
		private List<Dictionary<int,SmartObject>> smobject =  new List<Dictionary<int,SmartObject>>(group_count);
		private Dictionary<string,BTEvent> all_event = new Dictionary<string,BTEvent>();
		private Sequence root = new Sequence();

		//maybe we have to use prority queue
		private Queue<BTEvent> eventQueue = new Queue<BTEvent>();

		public static WorldManager getInstance(){
			if(instance == null){
				instance = new WorldManager();
			}
			return instance;
		}

		public void register_sm(SmartObject so){
			smobject[so.GroupID][so.GetInstanceID()] = so;
		}

		public void register_Event(BTEvent e){
			all_event[e.Name] = e;	
		}

		private bool calculate_transition(){
			bool success = false;
			//test implement



			//end
			return success;
		}

		public void set_goal(){
			
		}

	}
}