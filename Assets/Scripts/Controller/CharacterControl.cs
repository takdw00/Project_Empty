using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{


    //BehaviorTree for player controller
    protected BT_Selector sel_characterState; // 전체 트리
    protected BT_Selector sel_Stun_Status_Branch; // 경직 액션 분기 시퀸스
    protected BT_Sequence seq_Input_Status_Branch; // 입력 액션 분기 셀렉터
    protected BT_Selector sel_Status_Replacement_Branch; //스테이터스 변경 분기 셀렉터


    protected BT_Action_IDLE action_IDLE; // 기본 액션
    protected BT_Action_READY_TO_ATTACK action_READY_TO_ATTACK; // 공격 준비 액션
    protected BT_Action_STUN action_STUN; // 경직 액션
    protected BT_Action_INPUT action_INPUT; // 입력 액션
    protected BT_Action_AVOIDE action_AVOIDE; // 회피 액션
    protected BT_Action_GUARD action_GUARD; // 가드 액션
    protected BT_Action_MOVE action_MOVE; // 이동 액션
    protected BT_Action_ATTACK action_ATTACK; // 공격 액션
    protected BT_Action_SKILL_USE action_SKILL_USE; //임시  



    public virtual void ControlCommand()
    {

    }


}
