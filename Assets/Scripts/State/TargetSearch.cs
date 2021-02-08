﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSearch : State
{
    private void Awake()
    {
        character = transform.parent.GetComponent<Character>();
        character.SetTargetSearchState(GetComponent<TargetSearch>());
    }
    public override void Execution()
    {

    }
}
