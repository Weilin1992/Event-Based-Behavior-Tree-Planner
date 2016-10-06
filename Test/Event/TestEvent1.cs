using UnityEngine;
using System.Collections;
using BT;
public class TestEvent1 : BTEvent{
    SmartObject1 participant1;
    SmartObject2 participant2;

    int test_a = 1;

    int participant1_d;
    int participant2_d;
    

    public override bool check_precon()
    {
        return manager.database.GetData<int>(participant1.test1_index) == 2 
        &&  manager.database.GetData<int>(participant2.test2_index) == 3;
    }

    public override void set_postcon(){
        participant1.test1 = 0;
        participant2.test2 = 0;
    }


    public override void  set_participants(params SmartObject[] parti){
         participant1 = (SmartObject1) parti[0];
         participant2 = (SmartObject2) parti[1];
		}
 

    public override void set_postcon_database(){
        participant1_d = manager.database.GetData<int>(participant1.test1_index);
        participant2_d = manager.database.GetData<int>(participant2.test2_index);
        manager.database.SetData(participant1.test1_index,0);
        manager.database.SetData(participant2.test2_index,0);
    }

    public override void restore_database(){
        manager.database.SetData(participant1.test1_index,participant1_d);
        manager.database.SetData(participant2.test2_index,participant2_d);
    }


    protected override void init_group_id(){
        group_id.Add(SmartObject1.group_id);
        group_id.Add(SmartObject2.group_id);
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
