using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : State , IDamageable
{
    private void Awake()
    {
        character = transform.parent.GetComponent<Character>();
        character.SetHitState(GetComponent<Hit>());
    }
    public override void Execution()
    {

    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}
