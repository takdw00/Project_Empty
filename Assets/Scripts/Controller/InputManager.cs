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

    [SerializeField]Character character; // Input Manager�� ����� ĳ���� ��ũ��Ʈ���� �� ������ �������ش�.


    Dictionary<KeyCode, keyName> keyDictionary;




    //���� �Է� ����
    float horizontal;
    float vertical;

    //��ư Up ������ ����
    bool isPress;


    



    private void Start()
    {
        //Dictionary �̿��� �Է� Ű ����
        keyDictionary = new Dictionary<KeyCode, keyName>
            {
                {KeyCode.LeftArrow, keyName.Direction},
                {KeyCode.RightArrow, keyName.Direction},
                {KeyCode.UpArrow, keyName.Direction},
                {KeyCode.DownArrow, keyName.Direction},
                {KeyCode.Space, keyName.Avoide},
                {KeyCode.D, keyName.Guard},
                {KeyCode.A, keyName.Attack},
                {KeyCode.Q, keyName.SkillUse_1},
                {KeyCode.W, keyName.SkillUse_2},
                {KeyCode.E, keyName.SkillUse_3},
                {KeyCode.R, keyName.SkillUse_4},
                {KeyCode.Alpha1, keyName.SelectCharacter_1},
                {KeyCode.Alpha2, keyName.SelectCharacter_2},
                {KeyCode.Alpha3, keyName.SelectCharacter_3},
                {KeyCode.Alpha4, keyName.SelectCharacter_4}
            };

    }

    void InputCommand()
    {
        if (Input.anyKey)
        {
            foreach (var dic in keyDictionary)
            {
                if (Input.GetKeyDown(dic.Key)) // ������.
                {
                    switch (dic.Value)
                    {
                        //ȸ��
                        //���� ���߿��� ����� �� ����. (Tree���� Dec���� ó��)
                        //��ų ����߿��� ����� �� ����. (Tree���� Dec���� ó��)
                        //������ 1ȸ ȸ���Ѵ�.
                        //��� ���¸� ����Ѵ�.
                        //���带 ����Ѵ�.
                        //�̵��� ����Ѵ�.
                        case keyName.Avoide:
                            ButtonEvent_Avoide();
                            break;

                        //����
                        //ȸ�� ���߿��� ����� �� ����. (Tree���� Dec���� ó��)
                        //+ȸ�� �Է� ���� �Է½� ȸ�� ���� ����(�ٸ� �׼�)�� �Ѵ�.(�߰����� �ʿ�)
                        //��ų ����߿��� ����� �� ����. (Tree���� Dec���� ó��)
                        //������ 1ȸ ����
                        //��� ���¸� ����Ѵ�.
                        //���带 ����Ѵ�.
                        //�̵��� ����Ѵ�.
                        case keyName.Attack:
                            ButtonEvent_Attack();
                            break;
                    }
                }
                if (Input.GetKey(dic.Key)) // ������ �ִ� ��
                {
                    switch (dic.Value)
                    {
                        //����
                        //������ ���� ���´�.
                        //��� ���¸� ����Ѵ�.
                        //���带 ����ϴ� ���� �̵� �Ұ�.
                        case keyName.Guard:
                            ButtonEvent_Guard_Start();
                            break;

                        //�̵�
                        //������ ���� �ش� �������� �̵�
                        //��� ���¸� ����Ѵ�.
                        case keyName.Direction:
                            ButtonEvent_Direction_Start();
                            break;


                        //��ų ���
                        //������ ���� ��ų ��� �õ��Ѵ�.
                        //��� ���¸� ����Ѵ�.
                        //��Ÿ���߿��� ��ų�� ����� �ص� ������ �ʾƾ��Ѵ�.
                        case keyName.SkillUse_1:
                            ButtonEvent_SkillUse_1();
                            break;
                        case keyName.SkillUse_2:
                            ButtonEvent_SkillUse_2();
                            break;
                        case keyName.SkillUse_3:
                            ButtonEvent_SkillUse_3();
                            break;
                        case keyName.SkillUse_4:
                            ButtonEvent_SkillUse_4();
                            break;
                    }

                }

                if (Input.GetKeyUp(dic.Key)) //�´�
                {
                    switch (dic.Value)
                    {
                        //����
                        //���带 �����Ѵ�.
                        //��� ���¸� ����Ѵ�.
                        case keyName.Guard:
                            ButtonEvent_Guard_End();
                            break;

                        //�̵�
                        //�̵��� �����Ѵ�.
                        //��� ���¸� ����Ѵ�.
                        case keyName.Direction:
                            ButtonEvent_Direction_End();
                            break;

                        //��Ʈ�� ĳ���� ��ü
                        //������ ���� ��ü�� �̷�����.
                        case keyName.SelectCharacter_1:
                            //�̱���
                            ButtonEvent_SelectCharacter_1();
                            break;
                        case keyName.SelectCharacter_2:
                            //�̱���
                            ButtonEvent_SelectCharacter_2();
                            break;
                        case keyName.SelectCharacter_3:
                            //�̱���
                            ButtonEvent_SelectCharacter_3();
                            break;
                        case keyName.SelectCharacter_4:
                            //�̱���
                            ButtonEvent_SelectCharacter_4();
                            break;
                    }

                }

            }
        }
    }

    public void ContrrollCharacter(Character PlayableCharacter)
    {
        character = PlayableCharacter;
    }

    void ButtonEvent_Direction_Start()
    {
        //�̵�
        //������ ���� �ش� �������� �̵�
        //��� ���¸� ����Ѵ�.
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        character.SetMovement(new Vector3(horizontal, vertical, 0).normalized);
        character.isMove = true;
    }
    void ButtonEvent_Direction_End()
    {
        character.isMove = false;
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
    void ButtonEvent_Guard_Start()
    {
        //����
        //������ ���� ���´�.
        //��� ���¸� ����Ѵ�.
        //���带 ����ϴ� ���� �̵� �Ұ�.

    }
    void ButtonEvent_Guard_End()
    {
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
        character.isSkilluse_1 = true;
    }
    void ButtonEvent_SkillUse_2()
    {
        character.isSkilluse_2 = true;

    }
    void ButtonEvent_SkillUse_3()
    {
        character.isSkilluse_3 = true;
    }
    void ButtonEvent_SkillUse_4()
    {
        character.isSkilluse_4 = true;
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



