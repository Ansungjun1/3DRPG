using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkState : PlayerState
{
    public override void Enter(PlayerStateMachine stateMachine)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public override void Execute(PlayerStateMachine stateMachine, StraightSwordControllerDemoScript player)
    {
        if(!player.NPC.Contexts.GetComponent<Canvas>().enabled)
        {
            stateMachine.ChangeState(stateMachine.InputState);
        }
    }
    public override void Exit(PlayerStateMachine stateMachine)
    {

    }
}
