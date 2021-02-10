using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_MOVE : BT_Leaf
{
    public override bool Run()
    {
        if (character.IsMove)
        {
            character.CurrentState = character.MoveState;
            return true;
        }
        else
        {
            return false;
        }
    }
}
