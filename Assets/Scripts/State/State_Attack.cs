using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack : State
{
    public override void Execution()
    {
        
    }

    private void MeleeAttack()
    {
        InteractableObject hitObject;

        //공격 범위 길이
        float length = CharacterRef.Now_Attack_Length_Range;

        //공격 범위 폭
        //상단 위치
        Vector3 topPos = new Vector3(transform.position.x,transform.position.y - CharacterRef.Now_Attack_Width_Range,transform.position.z);
        //하단 위치
        Vector3 downPos = new Vector3(transform.position.x, transform.position.y + CharacterRef.Now_Attack_Width_Range, transform.position.z);

        Collider[] colls = Physics.OverlapCapsule(topPos, downPos, length, CharacterRef.Enemy_layerMask);

        for(int i=0; i<colls.Length; i++)
        {
            hitObject = colls[i].GetComponent<InteractableObject>();
            hitObject.IsHit = true;
        }
    }

    private void OnDrawGizmos()
    {

    }
}
