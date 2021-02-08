using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_STUN : BT_Leaf
{
    public override bool Run()
    {
        if (character.isStun)
        {
            character.SetState(character.GetStunState());
            return true;
        }
        else
        {
            return false;
        }
    }
}
