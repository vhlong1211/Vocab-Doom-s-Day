using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{   
    private float chasingTimeKeeper = 0;

    public override void EnterState(EnemyStateManager enemy){
        enemy.agent.speed = 5f;
        enemy.anim.SetTrigger("isRunning");
    }

    public override void UpdateState(EnemyStateManager enemy){
        float duration = 1f;
        if(Time.time - chasingTimeKeeper < duration)   return;

        chasingTimeKeeper = Time.time;
        enemy.agent.SetDestination(enemy.player.position);
    }

    //public override void OnCollisionEnter(EnemyStateManager enemy){
        
    //}
}
