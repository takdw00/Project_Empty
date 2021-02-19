using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    private void OnTriggerEnter(Collider other)
    {
        InteractableObject hitObject;
        
        
        if(hitObject = other.gameObject.GetComponent<InteractableObject>())
        {
            hitObject.IsHit = true;

            Debug.Log("Sword Hit object : " + hitObject.gameObject.name);
        }
        
        


    }
}
