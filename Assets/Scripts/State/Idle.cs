using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    private void Awake()
    {
        character = transform.parent.GetComponent<Character>();
        character.SetIdleState(GetComponent<Idle>());
    }
    public override void Execution()
    {
        Debug.Log("Idle state");
    }
}
