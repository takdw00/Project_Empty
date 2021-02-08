using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : State
{
    private void Awake()
    {
        character = transform.parent.GetComponent<Character>();
        character.SetStunState(GetComponent<Stun>());
    }
    public override void Execution()
    {

    }
}
