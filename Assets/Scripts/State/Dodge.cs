using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : State
{
    private void Awake()
    {
        character = transform.parent.GetComponent<Character>();
        character.SetDodgeeState(GetComponent<Dodge>());
    }
    public override void Execution()
    {

    }
}
