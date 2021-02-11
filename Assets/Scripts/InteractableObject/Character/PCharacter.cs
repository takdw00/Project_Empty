using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCharacter : Character
{
    //사용클래스
    CharacterControl controller;
    PCBehaviorTree player_Control;
    NPCBehaviorTree npcAI_Control;

    [SerializeField] bool isCurrentSelectedCharacter;


    #region Properties
    public PCBehaviorTree Player_Control { get { return player_Control; } set { player_Control = value; } }
    public NPCBehaviorTree NpcAI_Control { get { return npcAI_Control; } set { npcAI_Control = value; } }
    #endregion


    override protected void Awake()
    {
        base.Awake();

        ///Control State


        ///스탯설정(임시)
        Now_Speed = 10;

        //Defult state
        CurrentState = IdleState;
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

        controller.ControlCommand();

        CurrentState.Execution();
    }

    private void FixedUpdate()
    {
        

    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(transform.position, new Vector3(2,2,2));
    //    Debug.Log("Gizmos");
    //}
}
