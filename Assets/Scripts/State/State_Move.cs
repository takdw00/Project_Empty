using UnityEngine;

public class State_Move : State
{
    public override void Execution()
    {
        if(CharacterRef.IsMove)
        {
            Vector3 moveRes = CharacterRef.Movement * CharacterRef.Now_Speed * Time.deltaTime;
            CharacterRef.MyRigidbody.MovePosition(transform.position + moveRes);
        }
        else
        {
            //Debug.Log("�̵� ����");
        }
    }
}
