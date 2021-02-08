using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : State
{
    private void Awake()
    {
        character = transform.parent.GetComponent<Character>();
        character.SetGuardState(GetComponent<Guard>());
    }
    public override void Execution()
    {

    }
}
