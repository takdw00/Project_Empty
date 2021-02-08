using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviorTree : CharacterControl
{
    PCharacter character;

    private void Awake()
    {
        //부모 오브젝트 character 스크립트의 변수 연결 작업
        character = transform.parent.GetComponent<PCharacter>();
        character.SetNpcAIContol(GetComponent<NPCBehaviorTree>());

        //분기 노드
        //NPC 분기 트리는 재설정 필요.
        GameObject bt_Base = transform.GetChild(0).gameObject;
        //sel_characterState = bt_Base.GetComponent<BT_Selector>();
        //sel_Stun_Status_Branch = bt_Base.GetComponent<BT_Selector>();
        //seq_Input_Status_Branch = bt_Base.GetComponent<BT_Sequence>();
        //sel_Status_Replacement_Branch = bt_Base.GetComponent<BT_Selector>();

        //액션 노드
        GameObject bt_Action = transform.GetChild(1).gameObject;
        action_IDLE = bt_Action. GetComponent<BT_Action_IDLE>();
        action_READY_TO_ATTACK = bt_Action.GetComponent<BT_Action_READY_TO_ATTACK>();
        action_STUN = bt_Action.GetComponent<BT_Action_STUN>();
        action_INPUT = bt_Action.GetComponent<BT_Action_INPUT>();
        action_AVOIDE = bt_Action.GetComponent<BT_Action_AVOIDE>();
        action_GUARD = bt_Action.GetComponent<BT_Action_GUARD>();
        action_MOVE = bt_Action.GetComponent<BT_Action_MOVE>();
        action_ATTACK = bt_Action.GetComponent<BT_Action_ATTACK>();
        action_SKILL_USE = bt_Action.GetComponent<BT_Action_SKILL_USE>(); //임시
    }

}
