
using UnityEngine;

namespace BT
{
	public class SmartObject:MonoBehaviour
	{
		protected WorldManager manager;
	    protected int role_id = 0;
		protected int index = -1;
		// private string name = "";
		// public string Name{
		// 	get { return name == "" ? GetType ().Name : name;}
		// 	set { name = value;}
		// }
		public int RoleID{
			get { return role_id;}
		}
		public int Index{
			get{return index;}
			set{index = value;}
		}

		public void init(){
			manager = WorldManager.getInstance();
		}
		
	}
}

