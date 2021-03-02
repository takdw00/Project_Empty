using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Dodge : State
{
    [SerializeField]  float front_Delay;
    float now_Front_Delay;
    [SerializeField] float back_Delay;
    float now_Back_Delay;


    public override void Execution()
    {

        CharacterRef.IsDodge = false;
    }

    public override void Animation()
    {

    }

    //void Dodge()
    //{
    //    Debug.Log("선딜");
    //    now_Front_Delay += Time.deltaTime;
    //    if (now_Front_Delay > front_Delay)
    //    {
    //        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    //        CharacterRef.IsMove = false;
    //        CharacterRef.IsIdle = false;
    //        now_Back_Delay += Time.deltaTime;
    //        Debug.Log("회피");
    //    }
    //    if (now_Back_Delay > back_Delay)
    //    {
    //        gameObject.GetComponent<BoxCollider2D>().enabled = true; // 애니 상황에 맞춰 수정 필요
    //        now_Front_Delay = 0;
    //        now_Back_Delay = 0;
    //        CharacterRef.IsAttack = false;
    //        CharacterRef.IsBattle_Idle = true;
    //        Debug.Log("후딜");
    //    }
    //}

    void Dodge()
    {
        //Animator animator = CharacterRef.MyAnimator;

        //animator.runtimeAnimatorController
    }

}
