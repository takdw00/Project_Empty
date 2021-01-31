using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : State
{
    Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }
    public override void Execution()
    {
        Vector3 moveRes = character.GetMovemnet() * character.GetNowSpeed() * Time.deltaTime;
        character.c_Rigidbody2D.MovePosition(transform.position + moveRes);
    }
}
