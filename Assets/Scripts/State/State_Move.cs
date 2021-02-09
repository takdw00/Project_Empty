using UnityEngine;

public class State_Move : State
{
    public override void Execution()
    {
        if(CharacterRef.IsMove)
        {
            Vector3 moveRes = CharacterRef.Movement * CharacterRef.NowSpeed * Time.deltaTime;
            CharacterRef.MyRigidbody.MovePosition(transform.position + moveRes);
        }
        else
        {
            //Debug.Log("이동 정지");
        }
    }
}
