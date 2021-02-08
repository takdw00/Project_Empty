using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{
    private void Awake()
    {
        character = transform.parent.GetComponent<Character>();
        character.SetAttackState(GetComponent<Attack>());
    }
    public override void Execution()
    {

    }
}
