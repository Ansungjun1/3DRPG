using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    PlayerState playerState;

    public PlayerState talkState;
    public PlayerState InputState;

    StraightSwordControllerDemoScript _player;
    public PlayerStateMachine(StraightSwordControllerDemoScript player)
    {
        talkState = new TalkState();
        InputState = new InputHandler(player);

        playerState = InputState;

        playerState.Enter(this);

        _player = player;
    }

    public void ChangeState(PlayerState state)
    {
        playerState.Exit(this);
        playerState = state;
        playerState.Enter(this);
    }

    public void Update()
    {
        playerState.Execute(this, _player);
    }
}
