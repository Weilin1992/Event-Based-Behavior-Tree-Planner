using UnityEngine;
using System.Collections;
using BT;
public class TestEvent1 : BTEvent{
    SmartObject1 participant1;
    SmartObject2 participant2;

    public override bool check_precon()
    {
        return participant1.test1 == 2 && participant2.test2 == 3;
    }

    public override void set_postcon(){
        participant1.test1 = 0;
        participant2.test2 = 0;
    }
	

    



}
