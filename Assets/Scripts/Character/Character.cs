using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody2D c_Rigidbody2D;

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
    protected Move move;
    protected Attack attack;
    protected Death death;
    protected TargetSearch targetSearch;
    protected StateChanger stateChanger;

    //판단 변수
    public Vector3 movement;

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
        this.movement = vector3;
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
    public State GetMoveState()
    {
        return move;
    }



}
