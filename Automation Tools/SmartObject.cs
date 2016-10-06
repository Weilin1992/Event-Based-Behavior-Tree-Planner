
using UnityEngine;

namespace BT
{
	public class SmartObject:MonoBehaviour
	{
		protected WorldManager manager;
	    public static int group_id;
		protected int gameobject_id = 0;
		protected int index = -1;
		

		

		private int instance_id = -1;
		public int Instance{
			get{return instance_id == -1 ? GetInstanceID():instance_id;}
			set{instance_id = value;}
		}

		public int GroupID{
			get { return group_id;}
		}
		public int Index{
			get{return index;}
			set{index = value;}
		}

		public void init(){
			manager = WorldManager.getInstance();
		}
		
		protected virtual void register_database(){

		}



		protected virtual void update_database(){

		}
		
	}
}

