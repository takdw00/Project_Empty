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
        CharacterRef.MyAnimator.runtimeAnimatorController = characterState_AnimatorController;
        CharacterRef.MyAnimator.SetFloat("Direction_X", CharacterRef.Move_Direction.x);
        CharacterRef.MyAnimator.SetFloat("Direction_Y", CharacterRef.Move_Direction.y);
    }
}
