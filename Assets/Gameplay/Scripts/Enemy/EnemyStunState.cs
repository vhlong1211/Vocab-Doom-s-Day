using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunState : EnemyBaseState
{   
    private float stunTime;
    private float stunTimeKeeper = 0;

    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.agent.speed = 0f;
        enemy.agent.SetDestination(enemy.transform.position);
        enemy.anim.enabled = false;
    }

    public override void EnterState(EnemyStateManager enemy,float time)
    {
        enemy.agent.speed = 0f;
        enemy.agent.SetDestination(enemy.transform.position);
        enemy.anim.enabled = false;
        stunTime = time;
        stunTimeKeeper = Time.time;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        float duration = stunTime;
        if (Time.time - stunTimeKeeper < duration) return;

        stunTimeKeeper = Time.time;
        enemy.SwitchState(enemy.PatrollingState);
    }
}
