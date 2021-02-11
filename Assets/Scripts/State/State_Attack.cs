using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack : State
{
    Vector3 position;
    Vector3 range_Half;
    Quaternion direction;




    #region AttackRange
    GameObject attackDirection;
    AttackRange attackRange;
    #endregion



    private void Start()
    {
        position.x = transform.position.x+CharacterRef.Now_Attack_Width_Range / 2;
        range_Half.x = CharacterRef.Now_Attack_Length_Range / 2;
        direction = new Quaternion(0, 0, 225, 0); //기본 방향

        #region AttackRange
        //임시
        //나중에 무기 선택에 따라서 컴포넌트 교체작업 필요할거 같음.
        attackDirection = transform.Find("AttackDirection").gameObject;
        attackRange = transform.Find("AttackDirection").transform.Find("Weapon").transform.Find("Defult_Weapon").GetComponent<AttackRange>();
        #endregion


    }
    public override void Execution()
    {
        MeleeAttack();
    }

    private void MeleeAttack()
    {

        InteractableObject hitObject;

        direction.z = Determine_Direction_Of_Attack(CharacterRef.Movement);
        attackDirection.transform.rotation = direction; // 가시화를 위한 오브젝트 회전
        position = attackRange.transform.position;
        range_Half = attackRange.Range / 2;


        //실제 생성되는 ovelapBox는 AttackDirection의 회전 값에 영향을 받지 않는다.
        Collider[] colls = Physics.OverlapBox(position, range_Half, direction, CharacterRef.Enemy_layerMask);




        for (int i=0; i<colls.Length; i++)
        {   
            hitObject = colls[i].GetComponent<InteractableObject>();
            hitObject.IsHit = true;
        }
    }

    //공격 방향 각도 계산
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
            //어떤 방향에도 속하지 않음. 에러.
            return 225;
        }
    }

}
