using UnityEngine;

public class State_Move : State
{
    public override void Execution()
    {
        if(CharacterRef.IsMove)
        {
            Vector3 moveRes = CharacterRef.Move_Direction * CharacterRef.Now_Speed * Time.deltaTime;
            CharacterRef.MyRigidbody.MovePosition(transform.position + moveRes);
            //Debug.Log("X : "+CharacterRef.Movement.x+" Y : "+CharacterRef.Movement.y);
        }
        else
        {
            //Debug.Log("이동 정지");
        }
    }
}
