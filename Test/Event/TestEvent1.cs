using UnityEngine;
using System.Collections;
using BT;
public class TestEvent1 : BTEvent{
    SmartObject1 participant1;
    SmartObject2 participant2;

    int test_a = 1;

    public override bool check_precon()
    {
        return participant1.test1 == 2 
        && participant2.test2 == 3;
    }

    public override void set_postcon(){
        participant1.test1 = 0;
        participant2.test2 = 0;
    }

    public virtual void set_participants(params SmartObject[] parti){
         participant1 = (SmartObject1) parti[0];
         participant2 = (SmartObject2) parti[1];
		}
 
    protected override void init_BT(){
        root = new SequenceParallel(
            new LeafInvoke(test_increment)
        );
    }

    Result test_increment(){

        Result result = Result.Running;
        participant1.test1_inc(test_a);
        participant2.test_2_inc(test_a);

        if(participant1.test1 == 100 && participant2.test2 == 101)
            result = Result.Success;
        
        return result;
        
    }


}
