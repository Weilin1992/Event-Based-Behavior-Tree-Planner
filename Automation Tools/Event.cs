
using System.Collections.Generic;

namespace BT{
	public class Event:BTNode{
		private List<int> role_id = new List<int>();
		private double cost = 0.0;
		private BTNode root;
		public virtual bool check_precon(){return false;}
		public virtual void set_postcon(){}
		protected override Result Excute(){
			Result result =  root.Tick();
			if(result == Result.Success){
				set_postcon();
			}
			return result;
		}
		
	}
}