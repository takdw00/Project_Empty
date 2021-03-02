using UnityEngine;

public class State_Move : State
{
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
    }

}
