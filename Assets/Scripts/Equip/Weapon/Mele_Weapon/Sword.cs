using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] float front_Delay = 0.2f;
    float now_Front_Delay;
    [SerializeField] float back_Delay = 0.4f;
    float now_Back_Delay;

    private void OnTriggerEnter(Collider other)
    {
        InteractableObject hitObject;
        
        
        if(hitObject = other.gameObject.GetComponent<InteractableObject>())
        {
            hitObject.IsHit = true;

            Debug.Log("Sword Hit object : " + hitObject.gameObject.name);
        }
    }
    override public void Attack()
    {
        //Debug.Log("선딜 " + now_Front_Delay);
        now_Front_Delay += Time.deltaTime;
        if (now_Front_Delay > front_Delay)
        {
            gameObject.GetComponent<MeshCollider>().enabled = true;
            now_Back_Delay += Time.deltaTime;
            Debug.Log("공격");
        }
        if (now_Back_Delay > back_Delay)
        {
            gameObject.GetComponent<MeshCollider>().enabled = false; // 애니 상황에 맞춰 수정 필요
            now_Front_Delay = 0;
            now_Back_Delay = 0;
            CharacterRef.IsAttack = false;
            CharacterRef.IsIdle = false;
            CharacterRef.IsReadyToAttack = true;
            Debug.Log("후딜");
        }
    }
}
