using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MeleWeapon
{
    [SerializeField] float front_Delay = 5.0f;
    float now_Front_Delay;
    [SerializeField] float back_Delay = 2.0f;
    float now_Back_Delay;










    //override public void Attack() //1
    //{
    //    //Debug.Log("����");
    //    now_Front_Delay += Time.deltaTime;
    //    if (now_Front_Delay > front_Delay)
    //    {
    //        CharacterRef.IsMove = false;
    //        CharacterRef.IsIdle = false;
    //        gameObject.GetComponent<MeshCollider>().enabled = true;
    //        now_Back_Delay += Time.deltaTime;
    //        //Debug.Log("����");
    //    }
    //    if (now_Back_Delay > back_Delay)
    //    {
    //        gameObject.GetComponent<MeshCollider>().enabled = false; // �ִ� ��Ȳ�� ���� ���� �ʿ�
    //        now_Front_Delay = 0;
    //        now_Back_Delay = 0;
    //        CharacterRef.IsAttack = false;
    //        CharacterRef.IsBattle_Idle = true;
    //        //Debug.Log("�ĵ�");
    //    }
    //}



}
