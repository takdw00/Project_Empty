using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_MOVE : BT_Leaf
{
    public override bool Run()
    {
        if (character.isMove)
        {
            character.SetState(character.GetMoveState());
            return true;
        }
        else
        {
            return false;
        }
    }
}
