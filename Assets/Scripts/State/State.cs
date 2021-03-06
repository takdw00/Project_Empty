﻿using UnityEngine;

public abstract class State : MonoBehaviour
{
    private Character characterRef;
    protected Character CharacterRef { get { return characterRef; } private set { } }

    //캐릭터의 해당 상태 애니메이션 컨트롤러
    [SerializeField] protected RuntimeAnimatorController animatorController_CharacterState;
    protected float animation_Speed;


    public RuntimeAnimatorController AnimatorController_CharacterState { get { return animatorController_CharacterState; } }

    protected virtual void Awake()
    {
        characterRef = GetComponent<Character>();
    }

    public abstract void Execution();

    public abstract void Animation();


}
