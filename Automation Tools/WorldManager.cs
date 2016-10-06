using UnityEngine;
using System.Collections.Generic;

namespace BT{
	public class WorldManager  {

		public Blackboard database = new Blackboard();
		private static WorldManager instance;
		private const int group_count = 10;
		
		private List<Dictionary<int,SmartObject>> smobject =  new List<Dictionary<int,SmartObject>>(group_count);
		private Dictionary<string,BTEvent> all_event = new Dictionary<string,BTEvent>();
		private Sequence root = new Sequence();
		
		public SmartObject1 sm1;
		public SmartObject2 sm2;

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
			if(check_goal()){
				success = true;
				return success;
			}
			

			//end
			return success;
		}

		private void EventList(){
			
		}
		

		public bool check_goal(){
			return database.GetData<int>(sm1.test1_index) == 0 && database.GetData<int>(sm2.test2_index) ==0;
		}

	}
}