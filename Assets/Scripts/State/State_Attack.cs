using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack : State
{

    float front_Delay=0.2f;
    float now_Front_Delay;
    float back_Delay=0.4f;
    float now_Back_Delay;

    float now_Delay;


    #region empty
    #endregion



    private void Start()
    {


        #region empty
        #endregion


    }
    public override void Execution()
    {
        MeleeAttack();
    }

    private void MeleeAttack()
    {
        //Debug.Log("���� " + now_Front_Delay);
        now_Front_Delay +=Time.deltaTime;
        if(now_Front_Delay>front_Delay)
        {
            CharacterRef.Weapon_Right.gameObject.GetComponent<MeshCollider>().enabled=true; // �ִ� ��Ȳ�� ���� ���� �ʿ�
            now_Back_Delay +=Time.deltaTime;
            Debug.Log("����");
        }
        if(now_Back_Delay>back_Delay)
        {
            CharacterRef.Weapon_Right.gameObject.GetComponent<MeshCollider>().enabled = false; // �ִ� ��Ȳ�� ���� ���� �ʿ�
            now_Front_Delay = 0;
            now_Back_Delay = 0;
            CharacterRef.IsAttack = false;
            CharacterRef.IsIdle = false;
            CharacterRef.IsReadyToAttack = true;
            Debug.Log("�ĵ�");
        }
    }

    //���� ���� ���� ���
    float Determine_Direction_Of_Attack(Vector3 movement)
    {
        Vector3 zeroDegreeDirection = new Vector3(1, 0, 0);


        float angle = Quaternion.FromToRotation(Vector3.up, zeroDegreeDirection - movement).eulerAngles.z;

        if ((angle < 45 && angle > 315) || angle == 0)
        {
            return 0;
        }
        if (angle < 90 && angle > 0)
        {
            return 45;
        }
        if (angle < 135 && angle > 45)
        {
            return 90;
        }
        if (angle < 180 && angle > 90)
        {
            return 135;
        }
        if (angle < 225 && angle > 135)
        {
            return 180;
        }
        if (angle < 270 && angle > 180)
        {
            return 225;
        }
        if (angle < 315 && angle > 225)
        {
            return 270;
        }
        if(angle < 360 && angle > 270)
        {
            return 315;
        }
        else
        {
            //� ���⿡�� ������ ����. ����.
            return 225;
        }
    }

}
