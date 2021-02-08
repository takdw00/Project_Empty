using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_INPUT : BT_Leaf
{
    InputManager inputManager;

    private void Start()
    {
       inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
    }
    public override bool Run()
    {
        if (character.isInput)
        {
            inputManager.InputCommand();
            character.isInput = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}