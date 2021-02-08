using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : State
{
    private void Awake()
    {
        character = transform.parent.GetComponent<Character>();
        character.SetDeathState(GetComponent<Death>());
    }
    public override void Execution()
    {

    }
}
