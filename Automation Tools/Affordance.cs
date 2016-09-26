using UnityEngine;
using System.Collections.Generic;

namespace BT
{
	public class Affordance
	{
		public SmartObject owner;

		public List<SmartObject> user;
		public GameObject cur_user;
		public Dictionary<string,bool> owner_pre;
		public Dictionary<string,bool> owner_post;
		public Dictionary<string,bool> user_post;
		public Dictionary<string,bool> user_pre;
		public ActionDelegate f;


		private void pre_to_post(){

		}


	}
}