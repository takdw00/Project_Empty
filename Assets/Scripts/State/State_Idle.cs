using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idle : State
{
    private void Awake()
    {
        base.Awake();
        animation_Speed = 1;
    }
    public override void Execution()
    {
        //Debug.Log("Idle state");


    }

    public override void Animation()
    {
        CharacterRef.MyAnimator.runtimeAnimatorController = AnimatorController_CharacterState;
        CharacterRef.MyAnimator.SetFloat("Direction_X", CharacterRef.Move_Direction.x);
        CharacterRef.MyAnimator.SetFloat("Direction_Y", CharacterRef.Move_Direction.y);
        CharacterRef.MyAnimator.speed = animation_Speed;

        //�ӽ� ���߿� battle idle ������ �ű�� �Űܼ� �ۼ��� ��
        CharacterRef.Right_Hand.StateAction(CharacterRef.Right_Hand.AinmationController_Battle_Idle, CharacterRef.Move_Direction, animation_Speed);
        CharacterRef.Right_Hand.WeaponEffect.StateEffect(CharacterRef.Right_Hand.WeaponEffect.AinmationController_Battle_Idle, CharacterRef.Move_Direction, animation_Speed);
    }
}
