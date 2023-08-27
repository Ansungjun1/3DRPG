using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : PlayerState
{
    StraightSwordControllerDemoScript player;

    Command handleUpMove;
    Command handleDownMove;
    Command handleLeftMove;
    Command handleRightMove;
    Command handleVerticalReset;
    Command handleHorizontalReset;

    Command handleLightAttackCombo;
    Command handleHeavyAttackCombo;
    Command handleChargeAttackCombo;
    Command handleBackStepAttack;

    Command handleBlockToggle;
    Command handleBackStep;
    Command handleRoll;
    Command handleSprint;
    Command handleSprintReset;
    Command handleWalkOrRun;
    Command handleStrafeOn;
    Command handleStrafeOff;
    Command handleTwoHand;
    Command handleLightAttack;
    Command handleHeavyAttack;
    Command handleChargeAttack;


    public InputHandler(StraightSwordControllerDemoScript player_)
    {
        player = player_;

        handleLightAttackCombo = new HandleLightAttackCombo();
        handleHeavyAttackCombo = new HandleHeavyAttackCombo();
        handleChargeAttackCombo = new HandleChargeAttackCombo();
        handleBackStepAttack = new HandleBackStepAttack();

        handleBlockToggle = new HandleBlockToggle();
        handleBackStep = new HandleBackStep();
        handleRoll = new HandleRoll();
        handleSprint = new HandleSprint();
        handleSprintReset = new HandleSprintReset();
        handleWalkOrRun = new HandleWalkOrRun();
        handleStrafeOn = new HandleStrafeOn();
        handleStrafeOff = new HandleStrafeOff();
        handleTwoHand = new HandleTwoHand();
        handleLightAttack = new HandleLightAttack();
        handleHeavyAttack = new HandleHeavyAttack();
        handleChargeAttack = new HandleChargeAttack();

        handleUpMove = new HandleUpMove();
        handleDownMove = new HandleDownMove();
        handleLeftMove = new HandleLeftMove();
        handleRightMove = new HandleRightMove();
        handleVerticalReset = new HandleVerticalReset();
        handleHorizontalReset = new HandleHorizontalReset();
    }

    public void handleInput(PlayerStateMachine stateMachine)
    {
        //Attack
        if (Input.GetMouseButtonDown(0))
        {
            handleLightAttackCombo.execute(player);
        }
        //if (Input.GetKeyUp(KeyCode.Q))
        //{
        //    handleHeavyAttackCombo.execute(player);
        //}
        //if (Input.GetKeyUp(KeyCode.C))
        //{
        //    handleChargeAttackCombo.execute(player);
        //}
        if (Input.GetMouseButtonDown(0))
        {
            handleBackStepAttack.execute(player);
        }

        //Action
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    handleBlockToggle.execute(player);
        //}
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            handleBackStep.execute(player);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            handleRoll.execute(player);
        }
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            handleSprint.execute(player);
        }
        if (Input.GetKeyUp(KeyCode.CapsLock))
        {
            handleSprintReset.execute(player);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            handleWalkOrRun.execute(player);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            handleStrafeOn.execute(player);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            handleStrafeOff.execute(player);
        }
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    handleTwoHand.execute(player);
        //}
        if (Input.GetMouseButtonDown(0))
        {
            handleLightAttack.execute(player);
        }
        //if (Input.GetKeyUp(KeyCode.Q))
        //{
        //    handleHeavyAttack.execute(player);
        //}
        //if (Input.GetKeyUp(KeyCode.C))
        //{
        //    handleChargeAttack.execute(player);
        //}

        //Move
        if (Input.GetKey(KeyCode.W))
        {
            handleUpMove.execute(player);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            handleDownMove.execute(player);
        }
        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            handleVerticalReset.execute(player);
        }

        if (Input.GetKey(KeyCode.D))
        {
            handleRightMove.execute(player);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            handleLeftMove.execute(player);
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            handleHorizontalReset.execute(player);
        }


        //Quest
        if(Input.GetKey(KeyCode.G))
        {
            if(player.TalkNPC())
                stateMachine.ChangeState(stateMachine.talkState);
        }
    }


    public override void Enter(PlayerStateMachine stateMachine)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public override void Execute(PlayerStateMachine stateMachine, StraightSwordControllerDemoScript player)
    {
        player.SetMousePos(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        handleInput(stateMachine);
    }
    public override void Exit(PlayerStateMachine stateMachine)
    {
        player.ResetInput();
    }
}
