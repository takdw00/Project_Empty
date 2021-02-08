using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCharacter : Character
{
    //사용클래스

    [SerializeField] bool isCurrentSelectedCharacter;

    private void Awake()
    {
        //구성 클래스 연결
        c_Rigidbody2D = transform.parent.GetComponent<Rigidbody2D>();

        ///Control State
        //playerControl = GetComponent<PlayerControl>();
        //npcAI = GetComponent<NPCBehaviorTree>();


        ///스탯설정(임시)
        nowSpeed = 10;

        //base state
        SetState(GetIdleState());
    }

    


    private void Update()
    {
        if(isCurrentSelectedCharacter) // 나중에 캐릭터 변경할 때만 컨트롤러 상태를 바꾸도록 코드 수정할 것.
        {
            //플레이어 컨트롤일시 컨트롤러 상태를 플레이어 컨트롤 상태로 바꾼다.
            controller = player_Control;
        }
        else
        {
            //controller = npcAI;
        }

        if(Input.anyKey)
        {
            isInput = true;
        }

        controller.ControlCommand();

        state.Execution();
        
    }

    public void SetPlayerContol(PlayerControl control)
    {
        player_Control = control;
    }
    public void SetNpcAIContol(NPCBehaviorTree control)
    {
        npcAI_Control = control;
    }
}
