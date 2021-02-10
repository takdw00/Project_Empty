using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Dodge : State
{
    public override void Execution()
    {

        CharacterRef.IsDodge = false;
    }
}
