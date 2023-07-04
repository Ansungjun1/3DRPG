using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    StraightSwordControllerDemoScript player;

    Command buttonArrowUp;
    Command buttonArrowDown;
    Command buttonArrowLeft;
    Command buttonArrowRight;

    Command handleBlockToggle;
    Command handleBackStep;
    Command handleRoll;
    Command handleSprint;
    Command handleWalkOrRun;
    Command handleStrafeOn;
    Command handleStrafeOff;
    Command handleTwoHand;
    Command handleLightAttack;
    Command handleHeavyAttack;
    Command handleChargeAttack;

    private void Start()
    {
        player = FindObjectOfType<StraightSwordControllerDemoScript>();

        handleBlockToggle = new HandleBlockToggle();
        handleBackStep = new HandleBackStep();
        handleRoll = new HandleRoll();
        handleSprint = new HandleSprint();
        handleWalkOrRun = new HandleWalkOrRun();
        handleStrafeOn = new HandleStrafeOn();
        handleStrafeOff = new HandleStrafeOff();
        handleTwoHand = new HandleTwoHand();
        handleLightAttack = new HandleLightAttack();
        handleHeavyAttack = new HandleHeavyAttack();
        handleChargeAttack = new HandleChargeAttack();
    }


    private void Update()
    {
        handleInput();
    }

    public void handleInput()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            handleBlockToggle.execute(player);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            handleBackStep.execute(player);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            handleRoll.execute(player);
        }


        if (Input.GetKey(KeyCode.CapsLock))
        {
            handleSprint.execute(player);
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

        if (Input.GetKeyDown(KeyCode.Y))
        {
            handleTwoHand.execute(player);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            handleLightAttack.execute(player);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            handleHeavyAttack.execute(player);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            handleChargeAttack.execute(player);
        }
    }
}
