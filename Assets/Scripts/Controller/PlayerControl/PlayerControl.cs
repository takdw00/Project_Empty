using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : CharacterControl
{
    PCharacter character;
    private void Awake()
    {
        //�θ� ������Ʈ character ��ũ��Ʈ�� ���� ���� �۾�
        character = transform.parent.GetComponent<PCharacter>();
        character.SetPlayerContol(GetComponent<PlayerControl>());

        GameObject bt_Base = transform.GetChild(0).gameObject;
        sel_characterState = bt_Base.AddComponent<BT_Selector>();
        sel_Stun_Status_Branch = bt_Base.AddComponent<BT_Selector>();
        seq_Input_Status_Branch = bt_Base.GetComponent<BT_Sequence>();
        sel_Status_Replacement_Branch = bt_Base.AddComponent<BT_Selector>();

        //�׼� ���
        GameObject bt_Action = transform.GetChild(1).gameObject;
        action_IDLE = bt_Action.GetComponent<BT_Action_IDLE>();
        action_READY_TO_ATTACK = bt_Action.GetComponent<BT_Action_READY_TO_ATTACK>();
        action_STUN = bt_Action.GetComponent<BT_Action_STUN>();
        action_INPUT = bt_Action.GetComponent<BT_Action_INPUT>();
        action_AVOIDE = bt_Action.GetComponent<BT_Action_AVOIDE>();
        action_GUARD = bt_Action.GetComponent<BT_Action_GUARD>();
        action_MOVE = bt_Action.GetComponent<BT_Action_MOVE>();
        action_ATTACK = bt_Action.GetComponent<BT_Action_ATTACK>();
        action_SKILL_USE = bt_Action.GetComponent<BT_Action_SKILL_USE>(); //�ӽ�
    }
    private void Start()
    {
        //player controller
        sel_characterState.AddChildNode(sel_Stun_Status_Branch); // ���� �׼� �б�
        sel_characterState.AddChildNode(action_IDLE); //��� �׼�
        sel_characterState.AddChildNode(action_READY_TO_ATTACK); //�����غ� �׼�

        sel_Stun_Status_Branch.AddChildNode(action_STUN); //���� �׼�
        sel_Stun_Status_Branch.AddChildNode(seq_Input_Status_Branch); //�Է� �׼� �б�

        seq_Input_Status_Branch.AddChildNode(action_INPUT); //�Է� �׼�
        seq_Input_Status_Branch.AddChildNode(sel_Status_Replacement_Branch); //�������ͽ� ���� �б�

        sel_Status_Replacement_Branch.AddChildNode(action_AVOIDE); //ȸ�� �׼�
        sel_Status_Replacement_Branch.AddChildNode(action_GUARD); //���� �׼�
        sel_Status_Replacement_Branch.AddChildNode(action_MOVE); //�̵� �׼�
        sel_Status_Replacement_Branch.AddChildNode(action_ATTACK); //���� �׼�
        sel_Status_Replacement_Branch.AddChildNode(action_SKILL_USE); //��ų ��� �׼� ,���� ���� �ʿ��� �� ����.
    }
    public override void ControlCommand()
    {
        sel_characterState.Run();
    }
}
