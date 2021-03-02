using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack : State
{
    public override void Execution()
    {
        
    }

    public override void Animation()
    {
        CharacterRef.MyAnimator.runtimeAnimatorController = AnimatorController_CharacterState;
        CharacterRef.MyAnimator.SetFloat("Direction_X", CharacterRef.Attack_Direction.x);
        CharacterRef.MyAnimator.SetFloat("Direction_Y", CharacterRef.Attack_Direction.y);
        CharacterRef.MyAnimator.speed = CharacterRef.Right_Hand.WeaponSpeed;

        CharacterRef.Right_Hand.StateAction(CharacterRef.Right_Hand.AinmationController_Attack, CharacterRef.Attack_Direction, CharacterRef.Right_Hand.WeaponSpeed);

        //������ �ٶ󺸴� ���� ������
        CharacterRef.Move_Direction = CharacterRef.Attack_Direction;


    }


    //�ִϸ��̼ǿ��� ���� ��ȯ ���� �Լ���
    public void AttackIng()
    {
        CharacterRef.IsAttack = false;
        //Debug.Log("ĳ���� ���� ��");
    }
    public void AttackEnd()
    {
        CharacterRef.IsIdle = true;

        //Debug.Log("ĳ���� ���� ����");
    }
}
