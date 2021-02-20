using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack : State
{




    #region empty
    #endregion



    private void Start()
    {


        #region empty
        #endregion


    }
    public override void Execution()
    {
        CharacterRef.Weapon_Right.Attack();
    }

    private void MeleeAttack()
    {

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
