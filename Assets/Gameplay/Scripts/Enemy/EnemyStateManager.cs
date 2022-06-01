using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class EnemyStateManager : MonoBehaviour
{   
    //State machine variable
    EnemyBaseState currentState;
    public EnemyChasingState ChasingState = new EnemyChasingState();
    public EnemyPatrollingState PatrollingState = new EnemyPatrollingState();
    
    public NavMeshAgent agent;
    public EnemyCharUI enemyCharUI;
    [HideInInspector]
    public Transform player;
    [HideInInspector]
    public List<char> weakCharHolder = new List<char>();
    public Animator anim;
    

    private void Awake() {
        
    }
    // Start is called before the first frame update
    void Start()
    {   
        player = PlayerManager.Instance.player;
        currentState = PatrollingState;
        LoadCharHolder();
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);

        float speed = agent.velocity.magnitude / agent.speed ;
        //float speed = agent.speed / 5;
        if (agent.speed == 0) speed = 0;
        anim.SetFloat("Speed", speed, 0.1f, Time.deltaTime);
    }

    public void SwitchState(EnemyBaseState state){
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(agent.destination, 1f);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, 15f);
    }

    public void LoadCharHolder(){

        int index = Random.Range(0, LoadingManager.Instance.dictionary.Count-1);
        KeyValuePair<string, string> pair = LoadingManager.Instance.dictionary.ElementAt(index);
        List<int> weakIndexList = new List<int>();
        int charCount = pair.Key.Length;
        if (charCount <= 5)
        {
            int weakIndex1 = Random.Range(0, charCount);
            weakIndexList.Add(weakIndex1);
            weakCharHolder.Add(pair.Key[weakIndex1]);
        }
        else if (charCount <= 10)
        {
            int weakIndex1 = Random.Range(0, charCount);
            int weakIndex2 = weakIndex1;
            while (weakIndex2 == weakIndex1) {
                weakIndex2 = Random.Range(0, charCount);
            }
            weakIndexList.Add(weakIndex1);
            weakIndexList.Add(weakIndex2);
            weakCharHolder.Add(pair.Key[weakIndex1]);
            weakCharHolder.Add(pair.Key[weakIndex2]);
        }
        else {
            int weakIndex1 = Random.Range(0, charCount);
            int weakIndex2 = weakIndex1;
            while (weakIndex2 == weakIndex1)
            {
                weakIndex2 = Random.Range(0, charCount);
            }
            int weakIndex3 = weakIndex1;
            while (weakIndex3 == weakIndex1 || weakIndex3 == weakIndex2) {
                weakIndex3 = Random.Range(0, charCount);
            }
            weakIndexList.Add(weakIndex1);
            weakIndexList.Add(weakIndex2);
            weakIndexList.Add(weakIndex3);
            weakCharHolder.Add(pair.Key[weakIndex1]);
            weakCharHolder.Add(pair.Key[weakIndex2]);
            weakCharHolder.Add(pair.Key[weakIndex3]);
        }
        enemyCharUI.Init(pair,weakIndexList);
    }
}
