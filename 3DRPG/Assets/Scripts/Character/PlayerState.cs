using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public abstract void Enter(PlayerStateMachine stateMachine);
    public abstract void Execute(PlayerStateMachine stateMachine, StraightSwordControllerDemoScript player);
    public abstract void Exit(PlayerStateMachine stateMachine);
}