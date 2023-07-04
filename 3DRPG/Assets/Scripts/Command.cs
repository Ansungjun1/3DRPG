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