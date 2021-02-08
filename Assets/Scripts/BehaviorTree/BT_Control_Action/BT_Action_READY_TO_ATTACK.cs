using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_READY_TO_ATTACK : BT_Leaf
{
    public override bool Run()
    {
        if (character.isReadyToAttack)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
