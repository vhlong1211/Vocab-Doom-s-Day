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
    public bool isWin = false;
    public string currentLevel;

    public CanvasBookScreen bookScreen;
    private void Start()
    {
        DataManager.Instance.LoadData();
        bookScreen.LoadBook();
        SoundManager.Instance.PlayBackgroundSound(SoundManager.Instance.MenuBgSound);
        //Debug.Log(DataManager.Instance.playerData.rankData["A1"].Count + "-----");
    }

    private void Update()
    {
        if (startGameplayTrigger) {
            SpawnerManager.Instance.StartSpawnEnemy();
            BuffManager.Instance.StartSpawnBuff();
            CanvasGameplay.Instance.timerClock.Setup();
            PlayerManager.Instance.isStartGame = true;
            PlayerManager.Instance.InitPlayerStat();
            PlayerManager.Instance.player.GetStat();
            CanvasGameplay.Instance.Setup();
            startGameplayTrigger = false;
        }

        if (stopGameplayTrigger) {
            StopGameplay();
            stopGameplayTrigger = false;
        }
    }


    //TODO hoan thanh not xu ly player chet
    private void StopGameplay() {
        EnemyManager.Instance.ResetAll();
        SpawnerManager.Instance.StopAll();
        BuffManager.Instance.StopAll();        
        CanvasGameplay.Instance.timerClock.StopTime();
        SoundManager.Instance.StopBgMusic();
        PlayerManager.Instance.isStartGame = false;
        DataManager.Instance.playerData.gold += PlayerManager.Instance.goldCollected;
        if (!isWin)
        {
            CanvasGameplay.Instance.canvasDieScreen.OnOpen();
        }
        else {
            HandleWin();
        }
        DataManager.Instance.SaveData();
    }

    private void HandleWin() {
        isWin = false;
        CanvasGameplay.Instance.canvasWinScreen.OnOpen();
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.WinSound);
        //Save highscore
        if (DataManager.Instance.playerData.rankData.ContainsKey(currentLevel))
        {
            List<float> tempList = DataManager.Instance.playerData.rankData[currentLevel];
            tempList.Add(CanvasGameplay.Instance.timerClock.currentTime);
            tempList.Sort();

        }
        else {
            List<float> tempList = new List<float>();
            tempList.Add(CanvasGameplay.Instance.timerClock.currentTime);
            DataManager.Instance.playerData.rankData.Add(currentLevel, tempList);
        }
        //Save Level
        int curLv = MathUtility.LevelTypeToIndex(currentLevel);
        if (curLv == DataManager.Instance.playerData.mapLevel && curLv < 4) {
            DataManager.Instance.playerData.mapLevel = curLv + 1;
        }
    }
}
