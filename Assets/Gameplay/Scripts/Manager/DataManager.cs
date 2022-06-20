using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (data != "")
        {
            playerData = JsonUtility.FromJson<PlayerData>(data);
        }
    }

    public void SaveData() {
        var json = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString(DataTag.PLAYER_DATA, json);
    }

}

[System.Serializable]
public class PlayerData {
    public int health;

    public Dictionary<string, List<float>> rankData = new Dictionary<string, List<float>>();

}
