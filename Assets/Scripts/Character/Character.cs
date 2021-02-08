using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody2D c_Rigidbody2D;

    //이름
    private string Character_Nmae;

    //스탯
    protected float maxHP;
    protected float nowHP;
    protected float maxSpeed;
    protected float nowSpeed;
    protected float maxAttackPower;
    protected float nowAttackPower;
    protected float maxDefensePower;
    protected float nowDefensePower;

    //State
    protected State state;
    protected Idle idle;
    protected ReadyToAttack readyToAttack;
    protected Dodge Dodge;
    protected Guard guard;
    protected Move move;
    protected Attack attack;
    protected Death death;
    protected SkillUse skillUse;
    protected TargetSearch targetSearch;
    protected Hit hit;
    //protected StateChanger stateChanger;

    //Status enabled or not
    public bool isHit;
    public bool isInput;
    public bool isIdle;
    public bool isReadyToAttack;
    public bool isDodge;
    public bool isGuard;
    public bool isMove;
    public bool isAttack;
    public bool isSkilluse_1;
    public bool isSkilluse_2;
    public bool isSkilluse_3;
    public bool isSkilluse_4;

    //Control
    protected CharacterControl controller;
    protected PlayerControl player_Control;
    protected NPCBehaviorTree npcAI_Control;

    //판단 변수
    public Vector3 movement;

    public string GetCharacterNmae()
    {
        return Character_Nmae;
    }

    public Rigidbody2D GetRigidbody2D()
    {
        return c_Rigidbody2D;
    }

    public float GetNowSpeed()
    {
        return nowSpeed;
    }

    public void SetMovement(Vector3 vector3)
    {
        movement = vector3;
    }

    public Vector3 GetMovemnet()
    {
        return movement;
    }

    public State GetState()
    {
        return state;
    }
    public void SetState(State currentState)
    {
        state = currentState;
    }

    public Attack GetAttackState()
    {
        return attack;
    }
    public void SetAttackState(Attack state)
    {
        attack = state;
    }
    public Dodge GetDodgeeState()
    {
        return Dodge;
    }
    public void SetDodgeeState(Dodge state)
    {
        Dodge = state;
    }
    public Death GetDeathState()
    {
        return death;
    }
    public void SetDeathState(Death state)
    {
         death = state;
    }
    public Guard GetGuardState()
    {
        return guard;
    }
    public void SetGuardState(Guard state)
    {
        guard= state;
    }
    public Idle GetIdleState()
    {
        return idle;
    }
    public void  SetIdleState(Idle state)
    {
         idle = state;
    }
    public Move GetMoveState()
    {
        return move;
    }
    public void SetMoveState(Move state)
    {
         move = state;
    }
    public ReadyToAttack GetReadyToAttackState()
    {
        return readyToAttack;
    }
    public void SetReadyToAttackState(ReadyToAttack state)
    {
         readyToAttack= state;
    }
    public SkillUse GetSkillUseState()
    {
        return skillUse;
    }
    public void  SetSkillUseState(SkillUse state)
    {
         skillUse= state;
    }
    public Hit GetHitState()
    {
        return hit;
    }
    public void SetHitState(Hit state)
    {
        hit = state;
    }

    public TargetSearch GetTargetSearchState()
    {
        return targetSearch;
    }
    public void  SetTargetSearchState(TargetSearch state)
    {
         targetSearch= state;
    }
}
