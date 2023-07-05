using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void execute(StraightSwordControllerDemoScript player);
}


public class HandleBlockToggle : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleBlockToggle();
    }
}
public class HandleBackStep : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleBackStep();
    }
}
public class HandleRoll : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleRoll();
    }
}
public class HandleSprint : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleSprint();
    }
}
public class HandleSprintReset : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleSprintReset();
    }
}
public class HandleWalkOrRun : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleWalkOrRun();
    }
}
public class HandleStrafeOn : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleStrafeOn();
    }
}
public class HandleStrafeOff : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleStrafeOff();
    }
}
public class HandleTwoHand : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleTwoHand();
    }
}
public class HandleLightAttack : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleLightAttack();
    }
}
public class HandleHeavyAttack : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleHeavyAttack();
    }
}
public class HandleChargeAttack : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleChargeAttack();
    }
}
public class HandleLightAttackCombo : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleLightAttackCombo();
    }
}
public class HandleHeavyAttackCombo : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleHeavyAttackCombo();
    }
}
public class HandleChargeAttackCombo : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleChargeAttackCombo();
    }
}
public class HandleBackStepAttack : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.HandleBackStepAttack();
    }
}
public class HandleUpMove : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.SetVerticalMovement(1);
    }
}
public class HandleDownMove : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.SetVerticalMovement(-1);
    }
}
public class HandleVerticalReset : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.SetVerticalMovement(0);
    }
}
public class HandleLeftMove : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.SetHorizontalMovement(-1);
    }
}
public class HandleRightMove : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.SetHorizontalMovement(1);
    }
}
public class HandleHorizontalReset : Command
{
    public override void execute(StraightSwordControllerDemoScript player)
    {
        player.SetHorizontalMovement(0);
    }
}
