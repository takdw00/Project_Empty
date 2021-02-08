using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_GUARD : BT_Leaf
{
    public override bool Run()
    {
        if (character.isGuard)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
