using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace BT{
	public class WorldManager  {

		private class EventInstance{
			public BTEvent e;
			public List<SmartObject> participants;
			public EventInstance(BTEvent e, List<SmartObject> participants){
				this.e = e;
				this.participants = participants;
			}
		}

		public Blackboard database = new Blackboard();
		private static WorldManager instance;
		private const int group_count = 10;
		//admitedly, a factory mode could be better.
		private List<List<SmartObject>> smobject =  new List<List<SmartObject>>(group_count);
		public  Dictionary<string,BTEvent> all_event = new Dictionary<string,BTEvent>();
		private Dictionary<string,Dictionary<int,List<SmartObject>>> event_actors = new Dictionary<string,Dictionary<int,List<SmartObject>>>();
		private Dictionary<string,List<List<SmartObject>>> event_actor_combination = new Dictionary<string,List<List<SmartObject>>>(); 
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
			if(so.Index != -1){
				smobject[so.GroupID].Add(so);
				so.Index = smobject[so.GroupID].Count;
			}
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
			while(check_goal() != true){
				List<List<EventInstance>> event_to_excute;
			}
			return success;
		}
		
		private List<List<EventInstance>> generate_event_run_together(){
			List<EventInstance> eventAvalilible = event_availible();
			List<List<EventInstance>> event_to_excute = new List<List<EventInstance>>();
			int index = 0;

			while(index < eventAvalilible.Count){
				if(index == 0){
					foreach (var item in eventAvalilible){
						List<EventInstance> tmp = new List<EventInstance>();
						tmp.Add(item);
					}
				}
				else{
					
				}

				index++;
			}

			return event_to_excute;
			
		}
		

		private List<EventInstance> event_availible(){
			List<EventInstance> res = new List<EventInstance>();
			foreach (var item in all_event){
				BTEvent tmp = item.Value;
				foreach(var group in event_actor_combination[item.Key]){
					tmp.set_participants(group);
					if(tmp.check_precon()){
						res.Add(new EventInstance(tmp.Clone(),group));
					}
				}
			}
			return res;
		} 

		private void init_Event_Group_List(){
			foreach(var item in all_event){
				var actor = event_actors[item.Key];
				int pre = -1;
				foreach (var id in item.Value.group_id){
					if (id != pre){
						foreach(var sm in smobject[id]){
							actor[id].Add(sm);
						}
					}
					pre = id;
				}
			}
		}
		
		private void generate_event_conbination(){
			foreach(var item in all_event){
				event_actor_combination[item.Key] = combination(item.Key,item.Value.group_id);
			}
		}

		private List<List<SmartObject>> combination(string Key,List<int> group_id){
			int pre = -1;
			int pre_count = 1;
			List<List<SmartObject>> res = new List<List<SmartObject>>();
			foreach (var item in group_id){
				List<SmartObject> same_group = smobject[item];
				List<List<SmartObject>> tmp2 = new List<List<SmartObject>>();
				if(item != pre){
					pre_count = 1;
					foreach (var role in same_group){
						List<SmartObject> tmp1;
						if(res.Count != 0){
							foreach(var list in res){
								tmp1 = new List<SmartObject>(list);
								tmp1.Add(role);
								tmp2.Add(tmp1);
							}
						}
						else{
							tmp1 = new List<SmartObject>();
							tmp1.Add(role);
							tmp2.Add(tmp1);
						}
					}
				}
				else{
					foreach (var role in same_group){
						List<SmartObject> tmp1;
						if(res.Count != 0){
							foreach(var list in res){
								int k = pre_count;
								bool exist = false;
								while(k > 0){
									if (list[list.Count - k] == role){
										exist = true;
										break;
									}
									k--;
								}

								if (exist == true){
									break;
								}
								tmp1 = new List<SmartObject>(list);
								tmp1.Add(role);
								tmp2.Add(tmp1);
							}
						}
						else{
							tmp1 = new List<SmartObject>();
							tmp1.Add(role);
							tmp2.Add(tmp1);
						}
					}
					pre_count+=1;
				}

				res = tmp2;
				pre = item;
			}
			return res;
		}

		public bool check_goal(){
			return database.GetData<int>(sm1.test1_index) == 0 && database.GetData<int>(sm2.test2_index) ==0;
		}
	}
}