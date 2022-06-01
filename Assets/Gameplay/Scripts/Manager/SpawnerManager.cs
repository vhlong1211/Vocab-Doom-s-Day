using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{   
    private static SpawnerManager instance;

    public static SpawnerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SpawnerManager>();
            }

            return instance;
        }
    }

    public GameObject enemyPrefab;
    public List<Transform> spawnPlaces = new List<Transform>();

    private float spawnOffset = 5f;
    public int enemyCount = 0;
    private int enemyMax = 20;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.startGameplayTrigger) {
            StartCoroutine(SpawnEnemy());
            GameManager.Instance.startGameplayTrigger = false;
        }
    }

    public IEnumerator SpawnEnemy(){
        while(enemyCount< enemyMax)
        {
            float randomXDir = Random.Range(0,1);
            float randomZDir = Random.Range(0,1);
            randomXDir = randomXDir < 0.5 ? randomXDir = -1 : randomXDir = 1;
            randomZDir = randomZDir < 0.5 ? randomZDir = -1 : randomZDir = 1;
            float spawnWellIndex = Random.Range(0,5);
            Transform spawnWell = spawnPlaces[Mathf.FloorToInt(spawnWellIndex)];
            Vector3 spawnPosition = new Vector3(spawnWell.position.x + randomXDir * spawnOffset , 0 ,spawnWell.position.z + randomZDir * spawnOffset);
            Instantiate(enemyPrefab,spawnPosition,Quaternion.identity);
            enemyCount++;
            yield return new WaitForSeconds(2f);
        }
        yield return new WaitForSeconds(2f);
    }
}
