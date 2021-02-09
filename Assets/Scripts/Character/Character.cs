using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D myRigidbody;


    #region Character Stat Variables

    //SerailizeField로 한 것들은 인스펙터에서 디자인할 수 있도록 함

    [SerializeField] private float maxHP;
    private float nowHP;
    [SerializeField] private float maxSpeed;
    private float nowSpeed;
    [SerializeField] private float maxAttackPower;
    private float nowAttackPower;
    [SerializeField] private float maxDefensePower;
    private float nowDefensePower;

    #endregion


    #region States

    private State currentState;

    private State_Attack attackState;
    private State_Death deathState;
    private State_Dodge dodgeState;
    private State_Guard guardState;
    private State_Hit hitState;
    private State_Idle idleState;
    private State_Move moveState;
    private State_ReadyToAttack readyToAttackState;
    private State_SkillUse skillUseState;
    private State_TargetSearch targetSearchState;


    #endregion


    //판단 변수
    private Vector3 movement;

    #region Status enabled or not
    private bool isAttack;
    private bool isDeath;
    private bool isDodge;
    private bool isGuard;
    private bool isIdle;
    private bool isHit;
    private bool isInput;
    private bool isMove;
    private bool isReadyToAttack;
    private bool isSkilluse_1;
    private bool isSkilluse_2;
    private bool isSkilluse_3;
    private bool isSkilluse_4;



    #endregion

    #region Properties

    //읽기 전용
    public Rigidbody2D MyRigidbody { get { return myRigidbody; } }

    //파생 클래스에서만 쓰기 가능
    public float NowHP { get { return nowHP; } protected set { nowHP = value; } }
    public float NowSpeed { get { return nowSpeed; } protected set { nowSpeed = value; } }
    public float NowAttackPower { get { return nowAttackPower; } protected set { nowAttackPower = value; } }
    public float NowDefensePower { get { return nowDefensePower; } protected set { nowDefensePower = value; } }

    public bool IsAttack { get { return isAttack; } set { isAttack = value; } }
    public bool IsDeath { get { return isDeath; } set { isDeath = value; } }
    public bool IsDodge { get { return isDodge; } set { isDodge = value; } }
    public bool IsGuard { get { return isGuard; } set { isGuard = value; } }
    public bool IsIdle { get { return isIdle; } set { isIdle = value; } }
    public bool IsInput { get { return isInput; } set { isInput = value; } }
    public bool IsHit { get { return isHit; } set { isHit = value; } }
    public bool IsMove { get { return isMove; } set { isMove = value; } }
    public bool IsReadyToAttack { get { return isReadyToAttack; } set { isReadyToAttack = value; } }
    public bool IsSkilluse_1 { get { return isSkilluse_1; } set { isSkilluse_1 = value; } }
    public bool IsSkilluse_2 { get { return isSkilluse_2; } set { isSkilluse_2 = value; } }
    public bool IsSkilluse_3 { get { return isSkilluse_3; } set { isSkilluse_3 = value; } }
    public bool IsSkilluse_4 { get { return isSkilluse_4; } set { isSkilluse_4 = value; } }



    public State CurrentState { get { return currentState; } set { currentState = value; } }

    //읽기 전용
    public State_Attack AttackState { get { return attackState; } }
    public State_Death DeathState { get { return deathState; } }
    public State_Dodge DodgeState { get { return dodgeState; } }
    public State_Guard GuardState { get { return guardState; } }
    public State_Hit HitState { get { return hitState; } }
    public State_Idle IdleState { get { return idleState; } }
    public State_Move MoveState { get { return moveState; } }
    public State_ReadyToAttack ReadyToAttackState { get { return readyToAttackState; } }
    public State_SkillUse SkillUseState { get { return skillUseState; } }
    public State_TargetSearch TargetSearchState { get { return targetSearchState; } }

    public Vector3 Movement { get { return movement; } set { movement = value; } }


    #endregion

    protected virtual void Awake() 
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        //State
        attackState = GetComponent<State_Attack>();
        deathState = GetComponent<State_Death>();
        dodgeState = GetComponent<State_Dodge>();
        guardState = GetComponent<State_Guard>();
        hitState = GetComponent<State_Hit>();
        idleState = GetComponent<State_Idle>();
        moveState = GetComponent<State_Move>();
        readyToAttackState = GetComponent<State_ReadyToAttack>();
        skillUseState = GetComponent<State_SkillUse>();
        targetSearchState = GetComponent<State_TargetSearch>();
    }

}
