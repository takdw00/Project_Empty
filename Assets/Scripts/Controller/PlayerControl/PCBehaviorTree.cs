using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PCBehaviorTree : CharacterControl
{
    PCharacter character;
    private void Awake()
    {
        //�θ� ������Ʈ character ��ũ��Ʈ�� ���� ���� �۾�
        character = transform.parent.GetComponent<PCharacter>();
        character.Player_Control = GetComponent<PCBehaviorTree>();

        //�б� ���
        sel_CharacterState = gameObject.AddComponent<BT_Selector>();
        sel_Hit_Status_Branch = gameObject.AddComponent<BT_Selector>();
        seq_Input_Status_Branch = gameObject.AddComponent<BT_Sequence>();
        sel_Status_Replacement_Branch = gameObject.AddComponent<BT_Selector>();

        //�׼� ���
        action_IDLE = gameObject.AddComponent<BT_Action_IDLE>();
        action_READY_TO_ATTACK = gameObject.AddComponent<BT_Action_READY_TO_ATTACK>();
        action_HIT = gameObject.AddComponent<BT_Action_HIT>();
        action_INPUT = gameObject.AddComponent<BT_Action_INPUT>();
        action_AVOIDE = gameObject.AddComponent<BT_Action_DODGE>();
        action_GUARD = gameObject.AddComponent<BT_Action_GUARD>();
        action_MOVE = gameObject.AddComponent<BT_Action_MOVE>();
        action_ATTACK = gameObject.AddComponent<BT_Action_ATTACK>();
        action_SKILL_USE = gameObject.AddComponent<BT_Action_SKILL_USE>(); //�ӽ�
    }
    private void Start()
    {
        //Player controller
        sel_CharacterState.AddChildNode(sel_Hit_Status_Branch); // ���� �׼� �б�
        sel_CharacterState.AddChildNode(action_IDLE); //��� �׼�
        sel_CharacterState.AddChildNode(action_READY_TO_ATTACK); //�����غ� �׼�

        sel_Hit_Status_Branch.AddChildNode(action_HIT); //���� �׼�
        sel_Hit_Status_Branch.AddChildNode(seq_Input_Status_Branch); //�Է� �׼� �б�

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
        sel_CharacterState.Run();
    }
}
