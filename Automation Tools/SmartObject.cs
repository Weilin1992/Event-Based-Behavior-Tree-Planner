
using UnityEngine;

namespace BT
{
	public class SmartObject:MonoBehaviour
	{
		protected WorldManager manager;
	    public static int group_id;
		protected int index = -1;
		protected bool onEvent = false;
		public bool OnEvent{
			get{return onEvent;}
			set{onEvent  = value;}
		}
		public int InstanceID{
			get{return GetInstanceID();}
		}

		public int GroupID{
			get { return group_id;}
		}
		public int Index{
			get{return index;}
			set{index = value;}
		}

		protected virtual void Start(){
			manager = WorldManager.getInstance();
			manager.register_sm(this);
			register_database();
		}

		
		protected virtual void register_database(){}
		protected virtual void update_database(){}

		protected virtual void FixUpdate(){
			update_database();
		}
		
	}
}

