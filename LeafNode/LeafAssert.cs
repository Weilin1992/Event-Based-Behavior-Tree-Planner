using System;


namespace BT{

	public class LeafAssert:BTNode{
	protected Func<bool> func_assert = null;
		public LeafAssert(Func<bool> assertion){
			this.func_assert = assertion;
		}
		protected override Result Excute(){
			if(this.func_assert != null){
				bool result = func_assert.Invoke();
				if(result == true){
					return Result.Success;
				}
				else{
					return Result.Failed;
				}
			}
			else
            {
                throw new ApplicationException(this + ": No method given");
            }
		}
	}
}




