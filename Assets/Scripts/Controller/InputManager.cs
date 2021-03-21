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
        Dodge = 0,
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

    [SerializeField] CharacterManager characterManager; // Input Manager�� ����� ĳ���� ��ũ��Ʈ���� �� ������ �������ش�. ���� ���� �ʿ��ҵ�.


    Dictionary<KeyCode, keyName> keyDictionary;

    protected List<KeyCode> activeInputs = new List<KeyCode>();


    //���� �Է� ����
    float horizontal;
    float vertical;

    //��ư Up ������ ����
    //bool isPress;

    //���콺 �Է� ���� ����
    Camera myCamera;
    Vector3 mousePosition;






    private void Start()
    {
        //Dictionary �̿��� �Է� Ű ����
        keyDictionary = new Dictionary<KeyCode, keyName>
            {
                {KeyCode.A, keyName.Direction},
                {KeyCode.D, keyName.Direction},
                {KeyCode.W, keyName.Direction},
                {KeyCode.S, keyName.Direction},
                {KeyCode.Space, keyName.Dodge},
                {KeyCode.Mouse1, keyName.Guard},
                {KeyCode.Mouse0, keyName.Attack},
                {KeyCode.Z, keyName.SkillUse_1},
                {KeyCode.X, keyName.SkillUse_2},
                {KeyCode.C, keyName.SkillUse_3},
                {KeyCode.V, keyName.SkillUse_4},
                {KeyCode.Alpha1, keyName.SelectCharacter_1},
                {KeyCode.Alpha2, keyName.SelectCharacter_2},
                {KeyCode.Alpha3, keyName.SelectCharacter_3},
                {KeyCode.Alpha4, keyName.SelectCharacter_4}
            };
        myCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

    }

    public void InputCommand()
    {
        List<KeyCode> pressedInput = new List<KeyCode>();

        List<KeyCode> releasedInput = new List<KeyCode>();


        if (Input.anyKey || Input.anyKeyDown)
        {
            //�Է� ����
            foreach (var dic in keyDictionary)
            {
                if (Input.GetKeyDown(dic.Key))
                {
                    ButtonActionDown(dic.Value);
                    //Debug.Log(dic.Key + " Ű ������");
                }
                if (Input.GetKey(dic.Key))
                {
                    activeInputs.Remove(dic.Key); // �ߺ� �Է� ����
                    activeInputs.Add(dic.Key); // Ȱ��ȭ �� Ű �߰�, ��Ƽ�꿡�� �ϳ��� Ű�� �ϳ��� ����
                    pressedInput.Add(dic.Key); // �̹� ������Ʈ�� ���ȴ�  ��� Ű

                    //Debug.Log(dic.Key + " Ű ������ ��");

                    ButtonAction(dic.Value);

                }
            }
        }

        foreach (var code in activeInputs)
        {
            releasedInput.Add(code); // Ȱ��ȭ �� ��� Ű �߰�

            if (!pressedInput.Contains(code))
            {
                releasedInput.Remove(code);

                //Debug.Log(code + " Ű Ǯ��.");

                ButtonActionUp(keyDictionary[code]);
            }

        }

        activeInputs = releasedInput;
    }

    void ButtonAction(keyName name)
    {
        switch (name)
        {
            //����
            //������ ���� ���´�.
            //��� ���¸� ����Ѵ�.
            //���带 ����ϴ� ���� �̵� �Ұ�.
            case keyName.Guard:
                ButtonEvent_Guard_Start();
                //Debug.Log("���� ��");
                break;

            //�̵�
            //������ ���� �ش� �������� �̵�
            //��� ���¸� ����Ѵ�.
            case keyName.Direction:
                //Invoke("ButtonEvent_Direction_Start", 0.1f);
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

    void ButtonActionDown(keyName name)
    {
        switch (name)
        {
            //ȸ��
            //���� ���߿��� ����� �� ����. (Tree���� Dec���� ó��)
            //��ų ����߿��� ����� �� ����. (Tree���� Dec���� ó��)
            //������ 1ȸ ȸ���Ѵ�.
            //��� ���¸� ����Ѵ�.
            //���带 ����Ѵ�.
            //�̵��� ����Ѵ�.
            case keyName.Dodge:
                ButtonEvent_Dodge();
                //Debug.Log("ȸ�� ����");
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

    void ButtonActionUp(keyName name)
    {
        switch (name)
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
                Invoke("ButtonEvent_Direction_End", 0.1f);
                //ButtonEvent_Direction_End();
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

    void ButtonEvent_Direction_Start()
    {
        //�̵�
        //������ ���� �ش� �������� �̵�
        //��� ���¸� ����Ѵ�.

        //if (!characterManager.Character.IsAttack)
        //{

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");


        characterManager.Character.Move_Direction = new Vector3(horizontal, vertical, 0).normalized;
        
        //����� �Է����� ���� ���Ⱚ (0,0) �� ���� ����ó�� ���߿� �ٽ� �պ� ��
        //if(characterManager.Character.Move_Direction.x==0 && characterManager.Character.Move_Direction.y == 0)
        //{
        //    characterManager.Character.IsIdle = true;
        //    return;
        //}


        characterManager.Character.IsIdle = false;
        characterManager.Character.IsMove = true;

        //Debug.Log("�̵� ��ư ��������");
        //}
    }

    void ButtonEvent_Direction_End()
    {
        characterManager.Character.Move_Direction = new Vector3(horizontal, vertical, 0).normalized;

        characterManager.Character.IsIdle = true;
        characterManager.Character.IsMove = false;

        //Debug.Log("�̵� ��ư �´�.");
    }
    void ButtonEvent_Dodge()
    {
        //ȸ��
        //���� ���߿��� ����� �� ����. (Tree���� Dec���� ó��)
        //��ų ����߿��� ����� �� ����. (Tree���� Dec���� ó��)
        //������ 1ȸ ȸ���Ѵ�.
        //��� ���¸� ����Ѵ�.
        //���带 ����Ѵ�.
        //�̵��� ����Ѵ�.
        characterManager.Character.IsDodge = true;
        characterManager.Character.IsGuard = false;
        characterManager.Character.IsMove = false;
        //test
        Debug.Log("Dodge");
    }
    void ButtonEvent_Guard_Start()
    {
        //����
        //������ ���� ���´�.
        //��� ���¸� ����Ѵ�.
        //���带 ����ϴ� ���� �̵� �Ұ�.
        characterManager.Character.IsGuard = true;
        Debug.Log("Guard start");

    }
    void ButtonEvent_Guard_End()
    {
        characterManager.Character.IsGuard = false;
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

        if (characterManager.Character.IsIdle || characterManager.Character.IsMove) // ���� ���� ���ο� ���� �Է� ����
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0;
            characterManager.Character.Attack_Direction = mousePosition - characterManager.Character.transform.position;
            characterManager.Character.Attack_Direction = characterManager.Character.Attack_Direction.normalized;


            characterManager.Character.AnimationNumber = SetParameter(characterManager.Character.Attack_Direction);

            characterManager.Character.IsAttack = true;
            characterManager.Character.IsIdle = false;
            characterManager.Character.IsGuard = false;
            characterManager.Character.IsMove = false;

            //Debug.Log("���� ����" + characterManager.Character.Attack_Direction);
        }
    }
    void ButtonEvent_SkillUse_1()
    {
        characterManager.Character.IsSkilluse_1 = true;
    }
    void ButtonEvent_SkillUse_2()
    {
        characterManager.Character.IsSkilluse_2 = true;

    }
    void ButtonEvent_SkillUse_3()
    {
        characterManager.Character.IsSkilluse_3 = true;
    }
    void ButtonEvent_SkillUse_4()
    {
        characterManager.Character.IsSkilluse_4 = true;
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


    public virtual float SetParameter(Vector2 direction)
    {
        float posX = 0.5f;
        float posY = 0.866f;

        //Debug.Log(direction);


        if (direction.x > -posX && direction.x < posX && direction.y < -posY && direction.y > -1) // Down
        {
            //Debug.Log("Down" + direction);
            return 1;
        }
        if (direction.x <= -posX && direction.x >= -1 && direction.y <= 0 && direction.y >= -posY) // Left Dwon
        {
            //Debug.Log("Left Dwon" + direction);
            return 2;
        }
        if (direction.x > -1 && direction.x <= -posX && direction.y > 0 && direction.y <= posY) // Left Up
        {
            //Debug.Log("Left Up" + direction);
            return 3;
        }
        if (direction.x <= 1 && direction.x >= posX && direction.y >= -posY && direction.y <= 0) // Right Down
        {
            //Debug.Log("Right Down" + direction);
            return 4;
        }
        if (direction.x >= posX && direction.x < 1 && direction.y <= posY && direction.y > 0) // Right Up
        {
            //Debug.Log("Right Up" + direction);
            return 5;
        }
        if (direction.x > -posX && direction.x < posX && direction.y > posY && direction.y < 1) // Up
        {
            //Debug.Log("Up" + direction);
            return 6;
        }
        return 0;
    }

}



