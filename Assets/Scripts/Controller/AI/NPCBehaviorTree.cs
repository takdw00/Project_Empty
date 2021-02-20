using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviorTree : CharacterControl
{
    //�� Ŭ������ NPC AI�� �⺻�� �Ǵ� Ŭ�����̴�.
    //�� Ŭ������ ��� �޾� �پ��� AI Ŭ������ ���� ����ϵ��� �Ѵ�.




    PCharacter character;

    private void Awake()
    {
        //�θ� ������Ʈ character ��ũ��Ʈ�� ���� ���� �۾�
        character = transform.parent.transform.parent.GetComponent<PCharacter>();
        character.NpcAI_Control = GetComponent<NPCBehaviorTree>();

        //�б� ���
        //NPC �б� Ʈ���� �缳�� �ʿ�.
        //GameObject bt_Base = transform.GetChild(0).gameObject;
        //sel_characterState = bt_Base.GetComponent<BT_Selector>();
        //sel_Stun_Status_Branch = bt_Base.GetComponent<BT_Selector>();
        //seq_Input_Status_Branch = bt_Base.GetComponent<BT_Sequence>();
        //sel_Status_Replacement_Branch = bt_Base.GetComponent<BT_Selector>();

        //�׼� ���
        action_IDLE = gameObject.AddComponent<BT_Action_IDLE>();
        action_BATTLE_IDLE = gameObject.AddComponent<BT_Action_BATTLE_IDLE>();
        action_HIT = gameObject.AddComponent<BT_Action_HIT>();
        action_INPUT = gameObject.AddComponent<BT_Action_INPUT>();
        action_AVOIDE = gameObject.AddComponent<BT_Action_DODGE>();
        action_GUARD = gameObject.AddComponent<BT_Action_GUARD>();
        action_MOVE = gameObject.AddComponent<BT_Action_MOVE>();
        action_ATTACK = gameObject.AddComponent<BT_Action_ATTACK>();
        action_SKILL_USE = gameObject.AddComponent<BT_Action_SKILL_USE>(); //�ӽ�
    }

}
