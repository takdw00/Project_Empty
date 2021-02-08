using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyToAttack : State
{
    private void Awake()
    {
        character = transform.parent.GetComponent<Character>();
        character.SetReadyToAttackState(GetComponent<ReadyToAttack>());
    }
    public override void Execution()
    {

    }
}
