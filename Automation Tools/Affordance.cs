using UnityEngine;
using System.Collections.Generic;

namespace BT
{
	public class Affordance
	{
		public SmartObject owner;

		public List<SmartObject> user;
		public SmartObject cur_user;
		public Dictionary<string,bool> owner_pre;
		public Dictionary<string,bool> owner_post;
		public Dictionary<string,bool> user_post;
		public Dictionary<string,bool> user_pre;
		public ActionDelegate f;

		public Affordance(ActionDelegate f,SmartObject owner){
			this.owner = owner;
			this.f = f;
		}


		//transfer from precondition to post condition
		private void pre_to_post(){

		}

		public void set_pre(){

		}
		public void set_post(){

		}

		public void set_user(){

		}
		public void set_owner(){

		}

		public void set_cur_user(){

		}
		
		public void set_action(ActionDelegate f){
			this.f = f;
		}

	}
}