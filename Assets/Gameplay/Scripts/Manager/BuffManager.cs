using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    private static BuffManager instance;

    public static BuffManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BuffManager>();
            }

            return instance;
        }
    }
    public Transform healthPotionPrefab;
    public Transform speedPotionPrefab;
    public List<Transform> houseList = new List<Transform>();
    [HideInInspector]
    public List<int> existBuffIndex = new List<int>();

    public float spawnDuration = 5f;

    public IEnumerator SpawnBuff() {
        while (true) {
            yield return new WaitForSeconds(spawnDuration);
            if (existBuffIndex.Count > 3)
            {
                spawnDuration = 5f;
            }
            else
            {
                //Chose buff type
                Transform currentPrefab;
                if (Random.Range(0f, 1f) < 0.7f)
                {
                    currentPrefab = Instantiate(healthPotionPrefab);
                }
                else
                {
                    currentPrefab = Instantiate(speedPotionPrefab);
                }


                int index = Random.Range(0, houseList.Count);
                if (existBuffIndex.Contains(index))
                {
                    spawnDuration = 1f;
                    GameObject.Destroy(currentPrefab.gameObject);
                }
                else
                {
                    existBuffIndex.Add(index);
                    Vector3 spawnPos = houseList[index].position + houseList[index].forward * -3f + houseList[index].right * 6f;
                    currentPrefab.position = new Vector3(spawnPos.x, 1f, spawnPos.z);
                    currentPrefab.GetComponent<IBuff>().Setup(index);
                    spawnDuration = 10f;
                }
            }
        }        
    }
}
