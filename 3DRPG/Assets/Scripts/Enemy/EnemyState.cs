using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    public abstract void Enter(EnemyStateMachine stateMachine, StraightSwordControllerDemoScript player);
    public abstract void Execute(EnemyStateMachine stateMachine, EnemyAround around, EnemyDead dead, StraightSwordControllerDemoScript player);
    public abstract void Exit(EnemyStateMachine stateMachine);
}

public class EnemyAttackState : EnemyState
{
    public override void Enter(EnemyStateMachine stateMachine, StraightSwordControllerDemoScript player)
    {
        stateMachine.GetComponent<Animator>().CrossFade("OH_Light_Attack_01", 0.2f);
        stateMachine.GetComponent<Animator>().SetBool("isAction", true);
        stateMachine.myWeapon.GetComponent<Sword>().SwordCollider(true);
    }
    public override void Execute(EnemyStateMachine stateMachine, EnemyAround around, EnemyDead dead, StraightSwordControllerDemoScript player)
    {
        if (!stateMachine.GetComponent<Animator>().GetBool("isAction"))
        {
            if (!dead.isOn)
            {
                stateMachine.ChangeState(stateMachine.chaseState);
            }
            else
            {
                stateMachine.transform.LookAt(player.transform.position);
                stateMachine.GetComponent<Animator>().CrossFade("OH_Light_Attack_01", 0.2f);
                stateMachine.GetComponent<Animator>().SetBool("isAction", true);
                stateMachine.myWeapon.GetComponent<Sword>().SwordCollider(true);
            }
        }
    }
    
    public override void Exit(EnemyStateMachine stateMachine)
    {
        
    }
}
public class EnemyIdleState : EnemyState
{
    const float zeroTime = 0f;
    float RandTime = 0f;
    float WalkTime = 0;

    public override void Enter(EnemyStateMachine stateMachine, StraightSwordControllerDemoScript player)
    {
        RandTime = Random.Range(5, 10);
        WalkTime = Random.Range(5, 10);
        stateMachine.GetComponent<Animator>().SetBool("Walk", true);

        stateMachine.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
    }
    public override void Execute(EnemyStateMachine stateMachine, EnemyAround around, EnemyDead dead, StraightSwordControllerDemoScript player)
    {
        if (around.isOn)
        {
            stateMachine.ChangeState(stateMachine.chaseState);
        }


        if (zeroTime <= WalkTime)
        {
            
            WalkTime -= Time.deltaTime;
            stateMachine.transform.position += stateMachine.transform.forward * Time.deltaTime;
        }
        else if (zeroTime <= RandTime)
        {
            stateMachine.GetComponent<Animator>().SetBool("Walk", false);
            RandTime -= Time.deltaTime;
        }
        else
        {
            stateMachine.ChangeState(stateMachine.idleState);
        }
    }
    public override void Exit(EnemyStateMachine stateMachine)
    {
        stateMachine.GetComponent<Animator>().SetBool("Walk", false);
    }
}
public class EnemyChaseState : EnemyState
{
    public override void Enter(EnemyStateMachine stateMachine, StraightSwordControllerDemoScript player)
    {
        stateMachine.GetComponent<Animator>().SetBool("Run", true);
    }
    public override void Execute(EnemyStateMachine stateMachine, EnemyAround around, EnemyDead dead, StraightSwordControllerDemoScript player)
    {
        stateMachine.transform.LookAt(player.transform.position);
        stateMachine.transform.position += (player.transform.position - stateMachine.transform.position).normalized * Time.deltaTime * stateMachine.speed;

        if (!around.isOn)
        {
            stateMachine.ChangeState(stateMachine.idleState);
        }
        else if(dead.isOn)
        {
            stateMachine.ChangeState(stateMachine.attackState);
        }
    }

    public override void Exit(EnemyStateMachine stateMachine)
    {
        stateMachine.GetComponent<Animator>().SetBool("Run", false);
    }
}