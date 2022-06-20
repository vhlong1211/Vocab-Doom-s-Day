using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class GameManager : MonoBehaviour
{   
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }

    public bool startGameplayTrigger = false;
    public bool stopGameplayTrigger = false;

    private void FixedUpdate()
    {
        if (startGameplayTrigger) {
            Debug.Log("start trigger");
            SpawnerManager.Instance.StartSpawnEnemy();
            BuffManager.Instance.StartSpawnBuff();
            CanvasGameplay.Instance.timerClock.Setup();
            startGameplayTrigger = false;
        }

        if (stopGameplayTrigger) {
            Debug.Log("stop trigger");
            StopGameplay();
            stopGameplayTrigger = false;
        }
    }


    //TODO hoan thanh not xu ly player chet
    private void StopGameplay() {
        EnemyManager.Instance.ResetAll();
        SpawnerManager.Instance.StopAll();
        BuffManager.Instance.StopAll();
        CanvasGameplay.Instance.canvasDieScreen.OnOpen();
        CanvasGameplay.Instance.timerClock.StopTime();
    }
}
