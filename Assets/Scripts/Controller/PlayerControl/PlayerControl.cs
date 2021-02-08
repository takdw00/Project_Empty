using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : CharacterControl
{
    PCharacter character;
    private void Awake()
    {
        //부모 오브젝트 character 스크립트의 변수 연결 작업
        character = transform.parent.GetComponent<PCharacter>();
        character.SetPlayerContol(GetComponent<PlayerControl>());

        GameObject bt_Base = transform.GetChild(0).gameObject;
        sel_characterState = bt_Base.AddComponent<BT_Selector>();
        sel_Stun_Status_Branch = bt_Base.AddComponent<BT_Selector>();
        seq_Input_Status_Branch = bt_Base.GetComponent<BT_Sequence>();
        sel_Status_Replacement_Branch = bt_Base.AddComponent<BT_Selector>();

        //액션 노드
        GameObject bt_Action = transform.GetChild(1).gameObject;
        action_IDLE = bt_Action.GetComponent<BT_Action_IDLE>();
        action_READY_TO_ATTACK = bt_Action.GetComponent<BT_Action_READY_TO_ATTACK>();
        action_STUN = bt_Action.GetComponent<BT_Action_STUN>();
        action_INPUT = bt_Action.GetComponent<BT_Action_INPUT>();
        action_AVOIDE = bt_Action.GetComponent<BT_Action_AVOIDE>();
        action_GUARD = bt_Action.GetComponent<BT_Action_GUARD>();
        action_MOVE = bt_Action.GetComponent<BT_Action_MOVE>();
        action_ATTACK = bt_Action.GetComponent<BT_Action_ATTACK>();
        action_SKILL_USE = bt_Action.GetComponent<BT_Action_SKILL_USE>(); //임시
    }
    private void Start()
    {
        //player controller
        sel_characterState.AddChildNode(sel_Stun_Status_Branch); // 경직 액션 분기
        sel_characterState.AddChildNode(action_IDLE); //대기 액션
        sel_characterState.AddChildNode(action_READY_TO_ATTACK); //공격준비 액션

        sel_Stun_Status_Branch.AddChildNode(action_STUN); //경직 액션
        sel_Stun_Status_Branch.AddChildNode(seq_Input_Status_Branch); //입력 액션 분기

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
        sel_characterState.Run();
    }
}
