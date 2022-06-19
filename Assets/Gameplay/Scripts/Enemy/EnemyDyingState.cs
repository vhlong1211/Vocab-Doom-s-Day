using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDyingState : EnemyBaseState
{
    private float deadTimeKeeper;
    public override void EnterState(EnemyStateManager enemy)
    {
        //Debug.Log("Enter Dying State");
        deadTimeKeeper = Time.time;
        enemy.agent.enabled = false;
        enemy.collider.enabled = false;
        enemy.anim.enabled = true;
        enemy.anim.SetBool(AnimationTag.ENEMY_DEAD_TRIGGER,true);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        float duration = 3f;
        if (Time.time - deadTimeKeeper < duration) return;

        enemy.Die();
    }
}
