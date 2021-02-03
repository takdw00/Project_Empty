using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //1.플레이어의 입력을 받는다.
    //2.입력을 받고 캐릭터의 상태 판단 bool 값을 전환해준다.
    //3.이 스크립트에서 조건을 걸지 않도록 한다.
    //4.BehaviorTree 기반 스크립트에서 조건을 제시하고 판단한다.
    //5.BehaviorTree의 Action 스크립트에서 상태 전환을 실시한다.
    //6.각 상태에서 해당 상태에서 해야될 행동을 처리한다.
    //7.행동 처리 후 일정 시간(Time.deltatime)이 지난 다음 기본 상태(IDLE,REDY_TO_ATTACK)


    //키코드 분류용 keyName
    //Dictionary 사용
    
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
    


        

    //방향 입력 변수
    float horizontal;
    float vertical;

    private void Start()
    {

        //character = GetComponentInParent<Character>();

        //Dictionary 이용한 입력 키 감지
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



        //키 딕셔너리 설정
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

        //버튼 이벤트 델리게이트 연결
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

    private void Update()//임시 나중에 삭제
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
    //            if (Input.GetKeyDown(dic.Key)) // 눌렀다.
    //            {
    //                switch (dic.Value)
    //                {
    //                        //회피
    //                        //공격 도중에는 사용할 수 없다. (Tree에서 Dec으로 처리)
    //                        //스킬 사용중에는 사용할 수 없다. (Tree에서 Dec으로 처리)
    //                        //누르면 1회 회피한다.
    //                        //대기 상태를 취소한다.
    //                        //가드를 취소한다.
    //                        //이동을 취소한다.
    //                    case keyName.Avoide:
    //                        character.isAvoide = true;
    //                        character.isGuard = false;
    //                        character.isMove = false;
    //                        //test
    //                        Debug.Log("Avoide");
    //                        break;

    //                        //공격
    //                        //회피 도중에는 사용할 수 없다. (Tree에서 Dec으로 처리)
    //                        //+회피 입력 도중 입력시 회피 이후 공격(다른 액션)을 한다.(추가구현 필요)
    //                        //스킬 사용중에는 사용할 수 없다. (Tree에서 Dec으로 처리)
    //                        //누르면 1회 공격
    //                        //대기 상태를 취소한다.
    //                        //가드를 취소한다.
    //                        //이동을 취소한다.
    //                    case keyName.Attack:
    //                        character.isAttack = true;
    //                        character.isGuard = false;
    //                        character.isMove = false;
    //                        break;
    //                }
    //            }
    //            if (Input.GetKey(dic.Key)) // 눌리고 있는 중
    //            {
    //                switch (dic.Value)
    //                {
    //                        //가드
    //                        //누르는 동안 막는다.
    //                        //대기 상태를 취소한다.
    //                        //가드를 사용하는 동안 이동 불가.
    //                    case keyName.Guard:
    //                        character.isGuard = true;
    //                        character.isMove = false;
    //                        //test
    //                        Debug.Log("Guard start");
    //                        break;

    //                        //이동
    //                        //누르는 동안 해당 방향으로 이동
    //                        //대기 상태를 취소한다.
    //                    case keyName.Direction:
    //                        horizontal = Input.GetAxisRaw("Horizontal");
    //                        vertical = Input.GetAxisRaw("Vertical");
    //                        character.SetMovement(new Vector3(horizontal, vertical, 0).normalized);
    //                        character.isMove = true;
    //                        break;


    //                        //스킬 사용
    //                        //누르는 동안 스킬 사용 시도한다.
    //                        //대기 상태를 취소한다.
    //                        //쿨타임중에는 스킬을 사용을 해도 사용되지 않아야한다.
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

    //            if (Input.GetKeyUp(dic.Key)) //뗏다
    //            {
    //                switch (dic.Value)
    //                {
    //                        //가드
    //                        //가드를 종료한다.
    //                        //대기 상태를 취소한다.
    //                    case keyName.Guard:
    //                        character.isGuard = false;
    //                        //test
    //                        Debug.Log("Guard end");
    //                        break;

    //                        //이동
    //                        //이동을 종료한다.
    //                        //대기 상태를 취소한다.
    //                    case keyName.Direction:
    //                        character.isMove = false;
    //                        break;

    //                        //컨트롤 캐릭터 교체
    //                        //눌렀다 떼면 교체가 이뤄진다.
    //                    case keyName.SelectCharacter_1:
    //                        //미구현
    //                        break;
    //                    case keyName.SelectCharacter_2:
    //                        //미구현
    //                        break;
    //                    case keyName.SelectCharacter_3:
    //                        //미구현
    //                        break;
    //                    case keyName.SelectCharacter_4:
    //                        //미구현
    //                        break;
    //                }

    //            }

    //        }
    //    }
    //}
    void ButtonEvent_Direction()
    {
        //이동
        //누르는 동안 해당 방향으로 이동
        //대기 상태를 취소한다.
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        character.SetMovement(new Vector3(horizontal, vertical, 0).normalized);
        character.isMove = true;
    }
    void ButtonEvent_Avoide()
    {
        //회피
        //공격 도중에는 사용할 수 없다. (Tree에서 Dec으로 처리)
        //스킬 사용중에는 사용할 수 없다. (Tree에서 Dec으로 처리)
        //누르면 1회 회피한다.
        //대기 상태를 취소한다.
        //가드를 취소한다.
        //이동을 취소한다.
        character.isAvoide = true;
        character.isGuard = false;
        character.isMove = false;
        //test
        Debug.Log("Avoide");
    }
    void ButtonEvent_Guard()
    {
        //가드
        //누르는 동안 막는다.
        //대기 상태를 취소한다.
        //가드를 사용하는 동안 이동 불가.
        character.isGuard = false;
        //test
        Debug.Log("Guard end");
    }
    void ButtonEvent_Attack()
    {
        //공격
        //회피 도중에는 사용할 수 없다. (Tree에서 Dec으로 처리)
        //+회피 입력 도중 입력시 회피 이후 공격(다른 액션)을 한다.(추가구현 필요)
        //스킬 사용중에는 사용할 수 없다. (Tree에서 Dec으로 처리)
        //누르면 1회 공격
        //대기 상태를 취소한다.
        //가드를 취소한다.
        //이동을 취소한다.
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



