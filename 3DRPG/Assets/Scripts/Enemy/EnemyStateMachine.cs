using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    EnemyState enemyState;

    public EnemyState idleState;
    public EnemyState attackState;
    public EnemyState chaseState;

    EnemyAround around;

    public float speed = 2f;
    public GameObject myWeapon;

    private void Start()
    {
        int childNum = transform.childCount;
        for (int i = 0; i < childNum; i++)
        {
            if (transform.GetChild(i).GetComponent<EnemyAround>())
            {
                around = transform.GetChild(i).GetComponent<EnemyAround>();
                break;
            }
        }


        enemyState = new EnemyIdleState();
        enemyState.Enter(this.GetComponent<EnemyStateMachine>(), around.player);

        idleState = new EnemyIdleState();
        attackState = new EnemyAttackState();
        chaseState = new EnemyChaseState();
    }

    public void Update()
    {
        enemyState.Execute(this.GetComponent<EnemyStateMachine>(), around, GetComponent<EnemyDead>(), around.player);
    }

    public void ChangeState(EnemyState nextState)
    {
        enemyState.Exit(this.GetComponent<EnemyStateMachine>());
        enemyState = nextState;
        enemyState.Enter(this.GetComponent<EnemyStateMachine>(), around.player);
    }
}
