using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //1.�÷��̾��� �Է��� �޴´�.
    //2.�Է��� �ް� ĳ������ ���� �Ǵ� bool ���� ��ȯ���ش�.
    //3.�� ��ũ��Ʈ���� ������ ���� �ʵ��� �Ѵ�.
    //4.BehaviorTree ��� ��ũ��Ʈ���� ������ �����ϰ� �Ǵ��Ѵ�.
    //5.BehaviorTree�� Action ��ũ��Ʈ���� ���� ��ȯ�� �ǽ��Ѵ�.
    //6.�� ���¿��� �ش� ���¿��� �ؾߵ� �ൿ�� ó���Ѵ�.
    //7.�ൿ ó�� �� ���� �ð�(Time.deltatime)�� ���� ���� �⺻ ����(IDLE,REDY_TO_ATTACK)


    //Ű�ڵ� �з��� keyName
    //Dictionary ���
    
    enum keyName
    {
        Avoide = 0,
        Guard = 1,
        Direction = 2,
        Attack = 3,
        SkillUse_1 = 4,
        SkillUse_2 = 5,
        SkillUse_3 = 6,
        SkillUse_4 = 7,
        SelectCharacter_1 = 8,
        SelectCharacter_2 = 9,
        SelectCharacter_3 = 10,
        SelectCharacter_4 = 11,
    }
    delegate void ButtonEvenvt();


    [SerializeField] Character character;

    Dictionary<KeyCode, ButtonEvenvt> keyDictionary;
    ButtonEvenvt buttonEvenvt;
    


        

    //���� �Է� ����
    float horizontal;
    float vertical;

    private void Start()
    {

        //character = GetComponentInParent<Character>();

        //Dictionary �̿��� �Է� Ű ����
        //keyDictionary = new Dictionary<KeyCode, keyName>
        //    {
        //        {KeyCode.LeftArrow, keyName.Direction},
        //        {KeyCode.RightArrow, keyName.Direction},
        //        {KeyCode.UpArrow, keyName.Direction},
        //        {KeyCode.DownArrow, keyName.Direction},
        //        {KeyCode.Space, keyName.Avoide},
        //        {KeyCode.D, keyName.Guard},
        //        {KeyCode.A, keyName.Attack},
        //        {KeyCode.Q, keyName.SkillUse_1},
        //        {KeyCode.W, keyName.SkillUse_2},
        //        {KeyCode.E, keyName.SkillUse_3},
        //        {KeyCode.R, keyName.SkillUse_4},
        //        {KeyCode.Alpha1, keyName.SelectCharacter_1},
        //        {KeyCode.Alpha2, keyName.SelectCharacter_2},
        //        {KeyCode.Alpha3, keyName.SelectCharacter_3},
        //        {KeyCode.Alpha4, keyName.SelectCharacter_4}
        //    };



        //Ű ��ųʸ� ����
        keyDictionary = new Dictionary<KeyCode, ButtonEvenvt>
            {
                {KeyCode.LeftArrow, ButtonEvent_Direction},
                {KeyCode.RightArrow, ButtonEvent_Direction},
                {KeyCode.UpArrow, ButtonEvent_Direction},
                {KeyCode.DownArrow, ButtonEvent_Direction},
                {KeyCode.Space, ButtonEvent_Avoide},
                {KeyCode.D, ButtonEvent_Guard},
                {KeyCode.A, ButtonEvent_Attack},
                {KeyCode.Q, ButtonEvent_SkillUse_1},
                {KeyCode.W, ButtonEvent_SkillUse_2},
                {KeyCode.E, ButtonEvent_SkillUse_3},
                {KeyCode.R, ButtonEvent_SkillUse_4},
                {KeyCode.Alpha1, ButtonEvent_SelectCharacter_1},
                {KeyCode.Alpha2, ButtonEvent_SelectCharacter_2},
                {KeyCode.Alpha3, ButtonEvent_SelectCharacter_3},
                {KeyCode.Alpha4, ButtonEvent_SelectCharacter_4}
            };

        //��ư �̺�Ʈ ��������Ʈ ����
        buttonEvenvt += ButtonEvent_Direction;
        buttonEvenvt += ButtonEvent_Avoide;
        buttonEvenvt += ButtonEvent_Guard;
        buttonEvenvt += ButtonEvent_Attack;
        buttonEvenvt += ButtonEvent_SkillUse_1;
        buttonEvenvt += ButtonEvent_SkillUse_2;
        buttonEvenvt += ButtonEvent_SkillUse_3;
        buttonEvenvt += ButtonEvent_SkillUse_4;
        buttonEvenvt += ButtonEvent_SelectCharacter_1;
        buttonEvenvt += ButtonEvent_SelectCharacter_2;
        buttonEvenvt += ButtonEvent_SelectCharacter_3;
        buttonEvenvt += ButtonEvent_SelectCharacter_4;
    }

    private void Update()//�ӽ� ���߿� ����
    {
        InputCommand();
    }

    void InputCommand()
    {
        if(Input.anyKey)
        {
            foreach(var dic in keyDictionary)
            {
                dic.Value();
            }
        }
    }

    //void InputCommand2()
    //{
    //    if (Input.anyKey)
    //    {
    //        foreach (var dic in keyDictionary)
    //        {
    //            if (Input.GetKeyDown(dic.Key)) // ������.
    //            {
    //                switch (dic.Value)
    //                {
    //                        //ȸ��
    //                        //���� ���߿��� ����� �� ����. (Tree���� Dec���� ó��)
    //                        //��ų ����߿��� ����� �� ����. (Tree���� Dec���� ó��)
    //                        //������ 1ȸ ȸ���Ѵ�.
    //                        //��� ���¸� ����Ѵ�.
    //                        //���带 ����Ѵ�.
    //                        //�̵��� ����Ѵ�.
    //                    case keyName.Avoide:
    //                        character.isAvoide = true;
    //                        character.isGuard = false;
    //                        character.isMove = false;
    //                        //test
    //                        Debug.Log("Avoide");
    //                        break;

    //                        //����
    //                        //ȸ�� ���߿��� ����� �� ����. (Tree���� Dec���� ó��)
    //                        //+ȸ�� �Է� ���� �Է½� ȸ�� ���� ����(�ٸ� �׼�)�� �Ѵ�.(�߰����� �ʿ�)
    //                        //��ų ����߿��� ����� �� ����. (Tree���� Dec���� ó��)
    //                        //������ 1ȸ ����
    //                        //��� ���¸� ����Ѵ�.
    //                        //���带 ����Ѵ�.
    //                        //�̵��� ����Ѵ�.
    //                    case keyName.Attack:
    //                        character.isAttack = true;
    //                        character.isGuard = false;
    //                        character.isMove = false;
    //                        break;
    //                }
    //            }
    //            if (Input.GetKey(dic.Key)) // ������ �ִ� ��
    //            {
    //                switch (dic.Value)
    //                {
    //                        //����
    //                        //������ ���� ���´�.
    //                        //��� ���¸� ����Ѵ�.
    //                        //���带 ����ϴ� ���� �̵� �Ұ�.
    //                    case keyName.Guard:
    //                        character.isGuard = true;
    //                        character.isMove = false;
    //                        //test
    //                        Debug.Log("Guard start");
    //                        break;

    //                        //�̵�
    //                        //������ ���� �ش� �������� �̵�
    //                        //��� ���¸� ����Ѵ�.
    //                    case keyName.Direction:
    //                        horizontal = Input.GetAxisRaw("Horizontal");
    //                        vertical = Input.GetAxisRaw("Vertical");
    //                        character.SetMovement(new Vector3(horizontal, vertical, 0).normalized);
    //                        character.isMove = true;
    //                        break;


    //                        //��ų ���
    //                        //������ ���� ��ų ��� �õ��Ѵ�.
    //                        //��� ���¸� ����Ѵ�.
    //                        //��Ÿ���߿��� ��ų�� ����� �ص� ������ �ʾƾ��Ѵ�.
    //                    case keyName.SkillUse_1:
    //                        character.isSkilluse_1 = true;
    //                        break;
    //                    case keyName.SkillUse_2:
    //                        character.isSkilluse_2 = true;
    //                        break;
    //                    case keyName.SkillUse_3:
    //                        character.isSkilluse_3 = true;
    //                        break;
    //                    case keyName.SkillUse_4:
    //                        character.isSkilluse_4 = true;
    //                        break;
    //                }

    //            }

    //            if (Input.GetKeyUp(dic.Key)) //�´�
    //            {
    //                switch (dic.Value)
    //                {
    //                        //����
    //                        //���带 �����Ѵ�.
    //                        //��� ���¸� ����Ѵ�.
    //                    case keyName.Guard:
    //                        character.isGuard = false;
    //                        //test
    //                        Debug.Log("Guard end");
    //                        break;

    //                        //�̵�
    //                        //�̵��� �����Ѵ�.
    //                        //��� ���¸� ����Ѵ�.
    //                    case keyName.Direction:
    //                        character.isMove = false;
    //                        break;

    //                        //��Ʈ�� ĳ���� ��ü
    //                        //������ ���� ��ü�� �̷�����.
    //                    case keyName.SelectCharacter_1:
    //                        //�̱���
    //                        break;
    //                    case keyName.SelectCharacter_2:
    //                        //�̱���
    //                        break;
    //                    case keyName.SelectCharacter_3:
    //                        //�̱���
    //                        break;
    //                    case keyName.SelectCharacter_4:
    //                        //�̱���
    //                        break;
    //                }

    //            }

    //        }
    //    }
    //}
    void ButtonEvent_Direction()
    {
        //�̵�
        //������ ���� �ش� �������� �̵�
        //��� ���¸� ����Ѵ�.
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        character.SetMovement(new Vector3(horizontal, vertical, 0).normalized);
        character.isMove = true;
    }
    void ButtonEvent_Avoide()
    {
        //ȸ��
        //���� ���߿��� ����� �� ����. (Tree���� Dec���� ó��)
        //��ų ����߿��� ����� �� ����. (Tree���� Dec���� ó��)
        //������ 1ȸ ȸ���Ѵ�.
        //��� ���¸� ����Ѵ�.
        //���带 ����Ѵ�.
        //�̵��� ����Ѵ�.
        character.isAvoide = true;
        character.isGuard = false;
        character.isMove = false;
        //test
        Debug.Log("Avoide");
    }
    void ButtonEvent_Guard()
    {
        //����
        //������ ���� ���´�.
        //��� ���¸� ����Ѵ�.
        //���带 ����ϴ� ���� �̵� �Ұ�.
        character.isGuard = false;
        //test
        Debug.Log("Guard end");
    }
    void ButtonEvent_Attack()
    {
        //����
        //ȸ�� ���߿��� ����� �� ����. (Tree���� Dec���� ó��)
        //+ȸ�� �Է� ���� �Է½� ȸ�� ���� ����(�ٸ� �׼�)�� �Ѵ�.(�߰����� �ʿ�)
        //��ų ����߿��� ����� �� ����. (Tree���� Dec���� ó��)
        //������ 1ȸ ����
        //��� ���¸� ����Ѵ�.
        //���带 ����Ѵ�.
        //�̵��� ����Ѵ�.
        character.isAttack = true;
        character.isGuard = false;
        character.isMove = false;
    }
    void ButtonEvent_SkillUse_1()
    {

    }
    void ButtonEvent_SkillUse_2()
    {

    }
    void ButtonEvent_SkillUse_3()
    {

    }
    void ButtonEvent_SkillUse_4()
    {

    }
    void ButtonEvent_SelectCharacter_1()
    {

    }
    void ButtonEvent_SelectCharacter_2()
    {

    }
    void ButtonEvent_SelectCharacter_3()
    {

    }
    void ButtonEvent_SelectCharacter_4()
    {

    }

}



