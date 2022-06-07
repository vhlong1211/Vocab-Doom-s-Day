using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPushBackState : EnemyBaseState
{

    private float pushBackTimeKeeper = 0;

    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.agent.enabled = false;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        float duration = 0.5f;
        if (Time.time - pushBackTimeKeeper < duration) return;

        pushBackTimeKeeper = Time.time;
        if (enemy.rbody.velocity.magnitude < 0.1f) {
            enemy.agent.enabled = true;
            enemy.SwitchState(enemy.ChasingState);
        }
    }
}
