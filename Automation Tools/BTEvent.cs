
using System.Collections.Generic;

namespace BT{
	public class BTEvent:BTNode{
		private List<int> role_id = new List<int>();
		private double cost = 0.0;
		protected BTNode root;
		protected WorldManager manager;

		public virtual bool check_precon(){return false;}
		public virtual void set_postcon(){}
		public virtual void set_participants(params SmartObject[] parti){
		}

		protected override Result Excute(){
			Result result =  root.Tick();
			if(result == Result.Success){
				set_postcon();
			}
			return result;
		}
		
		protected virtual void init_BT(){
		}

		public  virtual void init(){
			init_BT();
			manager = WorldManager.getInstance();
			manager.register_Event(this);
		}
	}
}