using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataManager>();
            }

            return instance;
        }
    }
    public PlayerData playerData;
    public void LoadData() {
        var data = PlayerPrefs.GetString(DataTag.PLAYER_DATA, "");
        Debug.Log(data + "  haha");
        if (data != "")
        {
            //playerData = JsonUtility.FromJson<PlayerData>(data);
            playerData = JsonConvert.DeserializeObject<PlayerData>(data);
        }
    }

    public void SaveData() {
        var json = JsonUtility.ToJson(playerData);
        var json2 = JsonConvert.SerializeObject(playerData);
        PlayerPrefs.SetString(DataTag.PLAYER_DATA, json2);
    }

    public void ResetAllData() {
        playerData.mapLevel = 0;
        playerData.gold = 0;
        playerData.upgradeAtkLevel = 0;
        playerData.upgradeHealthLevel = 0;
        playerData.upgradeSpeedLevel = 0;
        playerData.upgradeCooldownLevel = 0;
        playerData.rankData.Clear();
        SaveData();
    }
}

[System.Serializable]
public class PlayerData {
    public int health;
    public int mapLevel;
    public int gold;
    public int upgradeAtkLevel;
    public int upgradeHealthLevel;
    public int upgradeSpeedLevel;
    public int upgradeCooldownLevel;

    public Dictionary<string, List<float>> rankData = new Dictionary<string, List<float>>();
}
