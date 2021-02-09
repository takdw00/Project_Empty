using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PCBehaviorTree : CharacterControl
{
    PCharacter character;
    private void Awake()
    {
        //부모 오브젝트 character 스크립트의 변수 연결 작업
        character = transform.parent.GetComponent<PCharacter>();
        character.Player_Control = GetComponent<PCBehaviorTree>();

        //분기 노드
        sel_CharacterState = gameObject.AddComponent<BT_Selector>();
        sel_Hit_Status_Branch = gameObject.AddComponent<BT_Selector>();
        seq_Input_Status_Branch = gameObject.AddComponent<BT_Sequence>();
        sel_Status_Replacement_Branch = gameObject.AddComponent<BT_Selector>();

        //액션 노드
        action_IDLE = gameObject.AddComponent<BT_Action_IDLE>();
        action_READY_TO_ATTACK = gameObject.AddComponent<BT_Action_READY_TO_ATTACK>();
        action_HIT = gameObject.AddComponent<BT_Action_HIT>();
        action_INPUT = gameObject.AddComponent<BT_Action_INPUT>();
        action_AVOIDE = gameObject.AddComponent<BT_Action_DODGE>();
        action_GUARD = gameObject.AddComponent<BT_Action_GUARD>();
        action_MOVE = gameObject.AddComponent<BT_Action_MOVE>();
        action_ATTACK = gameObject.AddComponent<BT_Action_ATTACK>();
        action_SKILL_USE = gameObject.AddComponent<BT_Action_SKILL_USE>(); //임시
    }
    private void Start()
    {
        //Player controller
        sel_CharacterState.AddChildNode(sel_Hit_Status_Branch); // 경직 액션 분기
        sel_CharacterState.AddChildNode(action_IDLE); //대기 액션
        sel_CharacterState.AddChildNode(action_READY_TO_ATTACK); //공격준비 액션

        sel_Hit_Status_Branch.AddChildNode(action_HIT); //경직 액션
        sel_Hit_Status_Branch.AddChildNode(seq_Input_Status_Branch); //입력 액션 분기

        seq_Input_Status_Branch.AddChildNode(action_INPUT); //입력 액션
        seq_Input_Status_Branch.AddChildNode(sel_Status_Replacement_Branch); //스테이터스 변경 분기

        sel_Status_Replacement_Branch.AddChildNode(action_AVOIDE); //회피 액션
        sel_Status_Replacement_Branch.AddChildNode(action_GUARD); //가드 액션
        sel_Status_Replacement_Branch.AddChildNode(action_MOVE); //이동 액션
        sel_Status_Replacement_Branch.AddChildNode(action_ATTACK); //공격 액션
        sel_Status_Replacement_Branch.AddChildNode(action_SKILL_USE); //스킬 사용 액션 ,이후 수정 필요할 수 있음.
    }
    public override void ControlCommand()
    {
        sel_CharacterState.Run();
    }
}
