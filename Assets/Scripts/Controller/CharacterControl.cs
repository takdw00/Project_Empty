using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{


    //BehaviorTree for player controller
    protected BT_Selector sel_CharacterState; // ��ü Ʈ��
    protected BT_Selector sel_Hit_Status_Branch; // ���� �׼� �б� ������
    protected BT_Sequence seq_Input_Status_Branch; // �Է� �׼� �б� ������
    protected BT_Selector sel_Status_Replacement_Branch; //�������ͽ� ���� �б� ������


    protected BT_Action_IDLE action_IDLE; // �⺻ �׼�
    protected BT_Action_BATTLE_IDLE action_BATTLE_IDLE; // ���� �غ� �׼�
    protected BT_Action_HIT action_HIT; // ���� �׼�
    protected BT_Action_INPUT action_INPUT; // �Է� �׼�
    protected BT_Action_DODGE action_AVOIDE; // ȸ�� �׼�
    protected BT_Action_GUARD action_GUARD; // ���� �׼�
    protected BT_Action_MOVE action_MOVE; // �̵� �׼�
    protected BT_Action_ATTACK action_ATTACK; // ���� �׼�
    protected BT_Action_SKILL_USE action_SKILL_USE; //�ӽ�  



    public virtual void ControlCommand()
    {

    }


}
