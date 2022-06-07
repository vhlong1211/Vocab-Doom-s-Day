using UnityEngine;
using System.Collections;

public class EnemyPatrollingState : EnemyBaseState
{   
    private float frontSightRange = 15f;
    private float backSightRange = 10f;
    private float walkPointRange = 10f;
    private float maxSearchSenseRange = 30f;
    private float walkTimeKeeper = 0;
    private float searchTimeKeeper = 0;
    
    public override void EnterState(EnemyStateManager enemy){
        enemy.agent.speed = 3;
    }

    public override void UpdateState(EnemyStateManager enemy){
        SearchWalkPoint(enemy);
        CheckPlayerAround(enemy);
    }

    public override void OnTriggerEnter(EnemyStateManager enemy,Collider hit){
        base.OnTriggerEnter(enemy,hit);
        if (Vector3.Distance(enemy.transform.position, enemy.player.position) < maxSearchSenseRange) {
            enemy.SwitchState(enemy.ChasingState);
        }  
    }

    private void SearchWalkPoint(EnemyStateManager enemy){
        float durarion = Random.Range(1.5f,2.5f);
        if(Time.time - walkTimeKeeper < durarion)   return;

        walkTimeKeeper = Time.time;
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        Vector3 walkPoint = new Vector3(enemy.transform.position.x + randomX, enemy.transform.position.y, enemy.transform.position.z + randomZ);
        enemy.agent.SetDestination(walkPoint);
    }

    private void CheckPlayerAround(EnemyStateManager enemy){
        float duration = 1f;
        if(Time.time - searchTimeKeeper < duration)   return;

        searchTimeKeeper = Time.time;
        float distance = Vector3.Distance(enemy.transform.position,enemy.player.position);
        Vector3 dirToTarget = enemy.player.position - enemy.transform.position ;
        float dot = Vector3.Dot(enemy.transform.forward , dirToTarget);

        if(distance < backSightRange && dot < 0){
            enemy.SwitchState(enemy.ChasingState);
        }else if(distance < frontSightRange && dot >= 0){
            enemy.SwitchState(enemy.ChasingState);
        }
    }

}
