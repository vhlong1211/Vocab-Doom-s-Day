using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{   
    private float chasingTimeKeeper = 0;
    private float maxSenseChaseRange = 40f;
    public override void EnterState(EnemyStateManager enemy){
        enemy.agent.speed = 5f;
        enemy.anim.SetTrigger("isRunning");
    }

    public override void UpdateState(EnemyStateManager enemy){
        float duration = 0.5f;
        if(Time.time - chasingTimeKeeper < duration)   return;

        chasingTimeKeeper = Time.time;
        enemy.agent.SetDestination(enemy.player.position);
        if (Vector3.Distance(enemy.transform.position, enemy.player.position) > maxSenseChaseRange) {
            enemy.SwitchState(enemy.PatrollingState);
        }
    }

    //public override void OnCollisionEnter(EnemyStateManager enemy){
        
    //}
}
