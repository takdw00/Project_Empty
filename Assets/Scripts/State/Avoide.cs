using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoide : State
{
    private void Awake()
    {
        character = transform.parent.GetComponent<Character>();
        character.SetAvoideState(GetComponent<Avoide>());
    }
    public override void Execution()
    {

    }
}
