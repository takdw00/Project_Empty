using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_INPUT : BT_Leaf
{
    public override bool Run()
    {
        if (character.isInput)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
