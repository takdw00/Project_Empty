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
        Now_Speed = 5;

        //Defult state
        CurrentState = IdleState;
        IsIdle = true;
    }


    private void Start()
    {
        //캐릭터 기본 애니메이션 (Idle)
        MyAnimator.runtimeAnimatorController = IdleState.AnimatorController_CharacterState;
        //초기 바라보는 방향 설정 필요함. 아래 셋 제대로 안됨.
        //MyAnimator.SetFloat("Movement_X", -0.1f);
        //MyAnimator.SetFloat("Movement_Y", -0.1f);

        //시작 무기(초기)
        right_Hand = transform.Find("Equip").transform.Find("Weapon_Right").transform.Find("PCharacter_Weapon").transform.Find("Melee_Weapon").transform.Find("Sword").transform.Find("Long_Sword").GetComponent<Weapon>();
        right_Hand.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        CurrentState.Execution();
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

        CurrentState.Animation();
    }


}
