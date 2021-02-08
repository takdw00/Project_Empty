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
        c_Rigidbody2D = GetComponent<Rigidbody2D>();

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
        if(isCurrentSelectedCharacter)
        {
            //플레이어 컨트롤일시 컨트롤러 상태를 플레이어 컨트롤 상태로 바꾼다.
            controller = player_Control;
        }
        else
        {
            //controller = npcAI;
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
