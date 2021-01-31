using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : CharacterControl
{
    float horizontal;
    float vertical;


    //BehaviorTree for player controller
    BT_Selector playerState;
    BT_Action_InputDirection inputDirection;



    private void Awake()
    {
        playerState = GetComponent<BT_Selector>();
        inputDirection = GetComponent<BT_Action_InputDirection>();

        //player controller
        playerState.AddChildNode(inputDirection);

    }
    public override void InputCommand()
    {
        playerState.Run();
    }
}
