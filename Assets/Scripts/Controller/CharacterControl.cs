using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    Character character;

    protected virtual void Update()
    {
        //가상 함수로 선언하여 자식 클래스의 업데이트를 사용할 수 있도록 한다.
    }
    protected virtual void FiexdUpdate()
    {

    }

    public virtual void InputCommand()
    {

    }


}
