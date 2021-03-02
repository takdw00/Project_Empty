using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idle : State
{
    public override void Execution()
    {
        //Debug.Log("Idle state");


    }

    public override void Animation()
    {
        CharacterRef.MyAnimator.runtimeAnimatorController = AnimatorController_CharacterState;
        CharacterRef.MyAnimator.SetFloat("Direction_X", CharacterRef.Move_Direction.x);
        CharacterRef.MyAnimator.SetFloat("Direction_Y", CharacterRef.Move_Direction.y);

        //임시 나중에 battle idle 구현시 거기로 옮겨서 작성할 것
        CharacterRef.Right_Hand.StateAction(CharacterRef.Right_Hand.AinmationController_Battle_Idle, CharacterRef.Move_Direction, 1);

    }
}
