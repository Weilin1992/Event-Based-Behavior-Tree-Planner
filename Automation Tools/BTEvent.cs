
using System.Collections.Generic;

namespace BT{
	public class BTEvent:BTNode{
		public List<int> group_id = new List<int>();
		private double cost = 0.0;
		protected BTNode root;
		protected static WorldManager manager;


		public virtual bool check_precon(){return false;}
		public virtual void set_postcon(){}

		public virtual void set_participants(List<SmartObject> parti){
		}
		protected virtual void init_group_id(){
		}

		public virtual void set_postcon_database(){}
		public virtual void restore_database(){}
		public virtual double calculate_cost(){
			return cost;
		}

		protected override Result Excute(){
			Result result =  root.Tick();
			if(result == Result.Success){
				set_postcon();
			}
			return result;
		}
		
		protected virtual void init_BT(){}

		protected virtual void rebuild_BT(){}

		public  virtual void init(){
			init_BT();
			manager = WorldManager.getInstance();
			manager.register_Event(this);
		}

		public virtual BTEvent Clone(){
			BTEvent newObject = new BTEvent();
			newObject.Name = this.Name;
			newObject.group_id = this.group_id;
			newObject.cost = this.cost;
			newObject.root = this.root;
			return newObject;
		}


	}
}