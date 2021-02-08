using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_IDLE : BT_Leaf
{
    public override bool Run()
    {
        if (character.isIdle)
        {
            character.SetState(character.GetIdleState());
            return true;
        }
        else
        {
            return false;
        }
    }
}
