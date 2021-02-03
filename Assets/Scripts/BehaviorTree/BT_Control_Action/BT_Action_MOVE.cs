using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_MOVE : BT_Leaf
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
        if(character.isMove)
        {
            character.SetState(character.GetMoveState());
        }
        return true;
    }
}
