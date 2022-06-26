using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager instance;

    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EnemyManager>();
            }

            return instance;
        }
    }

    public List<EnemyStateManager> enemyList = new List<EnemyStateManager>();
    public int deadEnemyCount = 0;
    public int maxEnemyDead = 30;

    private void Update()
    {
        if (deadEnemyCount == maxEnemyDead) {
            GameManager.Instance.stopGameplayTrigger = true;
            GameManager.Instance.isWin = true;
            deadEnemyCount = 0;
        }
    }
    public List<EnemyStateManager> OverlapEnemy(Transform main , float radius , float angle) {
        List<EnemyStateManager> listReturn = new List<EnemyStateManager>();
        foreach (EnemyStateManager enemy in enemyList) {
            if (Vector3.Distance(main.position, enemy.transform.position) < radius) {
                Vector3 targetDir = enemy.transform.position - main.position;
                float angleDiff = Vector3.Angle(targetDir, main.forward);
                //Debug.Log(angleDiff + "  see");
                if (angleDiff < angle) {
                    listReturn.Add(enemy);
                }               
            }
        }
        return listReturn;
    }

    public List<EnemyStateManager> GetEnemyFoward(Vector3 startPoint ,Vector3 endPoint , float width) {
        List<EnemyStateManager> listReturn = new List<EnemyStateManager>();
        foreach (EnemyStateManager enemy in enemyList)
        {
            float enemyDistance = MathUtility.DistancePointLine(enemy.transform.position, startPoint, endPoint);
            if (enemyDistance < width) {
                listReturn.Add(enemy);
            }
        }
        return listReturn;
    }

    public void ResetAll() {
        foreach (EnemyStateManager enemy in enemyList) {
            GameObject.Destroy(enemy.gameObject);
        }
        enemyList.Clear();
    }
}
