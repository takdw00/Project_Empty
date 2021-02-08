using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUse : State
{
    private void Awake()
    {
        character = transform.parent.GetComponent<Character>();
        character.SetSkillUseState(GetComponent<SkillUse>());
    }
    public override void Execution()
    {

    }
}
