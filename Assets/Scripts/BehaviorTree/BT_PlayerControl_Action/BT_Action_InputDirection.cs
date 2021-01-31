using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_InputDirection : BT_Leaf
{
    float horizontal;
    float vertical;

    Character character;

    private void Awake()
    {
        character = GetComponent<PCharacter>();
    }

    public override bool Run()
    {
        Debug.Log("플레이어 이동 입력중...");
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        character.SetMovement(new Vector3(horizontal, vertical, 0).normalized);

        character.SetState(character.GetMoveState());

        return true;
    }
}
