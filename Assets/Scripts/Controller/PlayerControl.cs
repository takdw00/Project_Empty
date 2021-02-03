using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : CharacterControl
{
    float horizontal;
    float vertical;


    //BehaviorTree for player controller
    BT_Selector playerState;

    BT_Action_MOVE action_MOVE;



    private void Awake()
    {
        playerState = GetComponent<BT_Selector>();
        action_MOVE = GetComponent<BT_Action_MOVE>();

        //player controller
        playerState.AddChildNode(action_MOVE);

    }
    public override void ControlCommand()
    {
        playerState.Run();
    }
}
