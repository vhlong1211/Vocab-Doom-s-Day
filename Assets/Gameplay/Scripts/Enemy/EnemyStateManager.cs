using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class EnemyStateManager : MonoBehaviour
{
    //State machine variable
    public EnemyBaseState currentState;
    public EnemyChasingState ChasingState = new EnemyChasingState();
    public EnemyPatrollingState PatrollingState = new EnemyPatrollingState();
    public EnemyPushBackState PushBackState = new EnemyPushBackState();
    public EnemyStunState StunState = new EnemyStunState();
    public EnemyDyingState DyingState = new EnemyDyingState();

    public NavMeshAgent agent;
    public Rigidbody rbody;
    public EnemyCharUI enemyCharUI;
    public Collider collider;
    //public Transform VietWordPool;

    [HideInInspector]
    public Transform player;
    [HideInInspector]
    //public Dictionary<char,int> weakCharHolder = new Dictionary<char,int>();
    public List<KeyValuePair<char, int>> weakCharHolder = new List<KeyValuePair<char, int>>();
    public Animator anim;

    public string debugState;
    private KeyValuePair<string, string> pair;


    private void Awake() {
        
    }
    private void OnEnable()
    {
        EnemyManager.Instance.enemyList.Add(this);
        agent.enabled = true;
        collider.enabled = true;
        currentState = PatrollingState;
        LoadCharHolder();
        currentState.EnterState(this);
    }
    // Start is called before the first frame update
    void Start()
    {   
        player = PlayerManager.Instance.player.transform;

    }

    // Update is called once per frame
    void Update()
    {
        debugState = currentState.ToString();
        currentState.UpdateState(this);
        float speed = agent.velocity.magnitude / agent.speed ;
        //float speed = agent.speed / 5;
        if (agent.speed == 0) speed = 0;
        anim.SetFloat("Speed", speed, 0.1f, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }

    public void SwitchState(EnemyBaseState state){
        currentState = state;
        currentState.EnterState(this);
    }

    public void SwitchState(EnemyBaseState state,float time) {
        currentState = state;
        currentState.EnterState(this, time);
    }

    public void Die() {

        //GameObject.Destroy(gameObject);
        enemyCharUI.hiddenCharList.Clear();
        weakCharHolder.Clear();
        foreach (Transform child in enemyCharUI.charHolder) {
            Destroy(child.gameObject);
        }
        SimplePool.Despawn(gameObject);
    }

    public void PrepareDie() {
        //Debug.Log("Prepare Die");
        SoundManager.Instance.PlayMonsterGrowl();
        EnemyManager.Instance.enemyList.Remove(this);
        EnemyManager.Instance.deadEnemyCount++;
        SpawnerManager.Instance.enemyCount--;
        enemyCharUI.floatingTextViet.gameObject.SetActive(true);
        SwitchState(DyingState);
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
        pair = LoadingManager.Instance.dictionary.ElementAt(index);
        enemyCharUI.floatingTextEng.text = pair.Key;
        enemyCharUI.floatingTextViet.text = pair.Value;
        List<int> weakIndexList = new List<int>();
        int charCount = pair.Key.Length;
        if (charCount <= 5)
        {
            int weakIndex1 = Random.Range(0, charCount);
            weakIndexList.Add(weakIndex1);
            //weakCharHolder.Add(pair.Key[weakIndex1],weakIndex1);
            weakCharHolder.Add(new KeyValuePair<char, int>(pair.Key[weakIndex1], weakIndex1));
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
            //weakCharHolder.Add(pair.Key[weakIndex1],weakIndex1);
            //weakCharHolder.Add(pair.Key[weakIndex2],weakIndex2);
            weakCharHolder.Add(new KeyValuePair<char, int>(pair.Key[weakIndex1], weakIndex1));
            weakCharHolder.Add(new KeyValuePair<char, int>(pair.Key[weakIndex2], weakIndex2));
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
            //weakCharHolder.Add(pair.Key[weakIndex1],weakIndex1);
            //weakCharHolder.Add(pair.Key[weakIndex2],weakIndex2);
            //weakCharHolder.Add(pair.Key[weakIndex3],weakIndex3);
            weakCharHolder.Add(new KeyValuePair<char, int>(pair.Key[weakIndex1], weakIndex1));
            weakCharHolder.Add(new KeyValuePair<char, int>(pair.Key[weakIndex2], weakIndex2));
            weakCharHolder.Add(new KeyValuePair<char, int>(pair.Key[weakIndex3], weakIndex3));
        }
        enemyCharUI.Init(pair,weakIndexList);
    }
}
