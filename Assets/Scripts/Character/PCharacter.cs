using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCharacter : Character
{
    //사용클래스
    CharacterControl controller;
    PlayerControl playerControl;
    NPCBehaviorTree npcAI;
    [SerializeField] bool playerSelect;

    private void Awake()
    {
        //구성 클래스 연결
        c_Rigidbody2D = GetComponent<Rigidbody2D>();
        ///Control State
        controller = GetComponent<CharacterControl>();
        playerControl = GetComponent<PlayerControl>();
        npcAI = GetComponent<NPCBehaviorTree>();

        ///Character State
        state = GetComponent<State>();
        move = GetComponent<Move>();

        ///스탯설정(임시)
        nowSpeed = 10;
    }

    


    private void Update()
    {
        if(playerSelect)
        {
            //플레이어 컨트롤일시 컨트롤러 상태를 플레이어 컨트롤 상태로 바꾼다.
            controller = playerControl;
        }
        else
        {
            //controller = npcAI;
        }

        controller.InputCommand();

        state.Execution();
        
    }
}
