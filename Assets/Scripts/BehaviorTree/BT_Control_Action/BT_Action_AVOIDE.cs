using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_AVOIDE : BT_Leaf
{
    public override bool Run()
    {
        if (character.isAvoide)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
