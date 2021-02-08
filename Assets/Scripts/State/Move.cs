using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : State
{
    private void Awake()
    {
        character = transform.parent.GetComponent<Character>();
        character.SetMoveState(GetComponent<Move>());
    }
    public override void Execution()
    {
        Vector3 moveRes = character.GetMovemnet() * character.GetNowSpeed() * Time.deltaTime;
        character.c_Rigidbody2D.MovePosition(transform.position + moveRes);
    }
}
