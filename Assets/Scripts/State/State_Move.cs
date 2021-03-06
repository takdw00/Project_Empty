using UnityEngine;

public class State_Move : State
{
    private void Awake()
    {
        base.Awake();
        animation_Speed = 1;
    }

    public override void Execution()
    {
        Vector3 moveRes = CharacterRef.Move_Direction * CharacterRef.Now_Speed * Time.deltaTime;
        CharacterRef.MyRigidbody.MovePosition(transform.position + moveRes);
        //Debug.Log("X : "+CharacterRef.Movement.x+" Y : "+CharacterRef.Movement.y);
    }

    public override void Animation()
    {
        CharacterRef.MyAnimator.runtimeAnimatorController = AnimatorController_CharacterState;
        CharacterRef.MyAnimator.SetFloat("Direction_X", CharacterRef.Move_Direction.x);
        CharacterRef.MyAnimator.SetFloat("Direction_Y", CharacterRef.Move_Direction.y);

        CharacterRef.Right_Hand.StateAction(CharacterRef.Right_Hand.AinmationController_Battle_Run, CharacterRef.Move_Direction, animation_Speed);
        CharacterRef.Right_Hand.WeaponEffect.StateEffect(CharacterRef.Right_Hand.WeaponEffect.AinmationController_Battle_Idle, CharacterRef.Move_Direction, animation_Speed);
    }

}
