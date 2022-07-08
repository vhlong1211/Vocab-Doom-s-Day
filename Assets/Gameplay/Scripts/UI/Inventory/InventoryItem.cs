using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public UpgradeType type;
    public UpgradeScriptable upgradeConfig;
    public List<GameObject> levelColumn = new List<GameObject>();
    public Text priceTxt;
    private int currentUpgradeLv;

    private void Start()
    {
        GetUpgradeLevel();
    }

    private void OnEnable()
    {
        Setup();
    }

    public void OnUpgradeClick() {
        if (DataManager.Instance.playerData.gold < upgradeConfig.upgradeCost[currentUpgradeLv] || currentUpgradeLv >=4)
        {
            SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
            Debug.Log(upgradeConfig.upgradeCost[currentUpgradeLv] + "//" + currentUpgradeLv);
        }
        else {
            SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.UpgradeSound);
            DataManager.Instance.playerData.gold -= upgradeConfig.upgradeCost[currentUpgradeLv];
            currentUpgradeLv++;
            Setup();
            if (type == UpgradeType.Attack)
            {
                DataManager.Instance.playerData.upgradeAtkLevel++;
            }
            else if (type == UpgradeType.Health) {
                DataManager.Instance.playerData.upgradeHealthLevel++;
            }
            else if (type == UpgradeType.Speed)
            {
                DataManager.Instance.playerData.upgradeSpeedLevel++;
            }
            else if (type == UpgradeType.Cooldown)
            {
                DataManager.Instance.playerData.upgradeCooldownLevel++;
            }
            DataManager.Instance.SaveData();
        }
    }

    public void GetUpgradeLevel() {
        if (type == UpgradeType.Attack) {
            currentUpgradeLv = DataManager.Instance.playerData.upgradeAtkLevel;
        }else if (type == UpgradeType.Health) {
            currentUpgradeLv = DataManager.Instance.playerData.upgradeHealthLevel;
        }
        else if (type == UpgradeType.Speed)
        {
            currentUpgradeLv = DataManager.Instance.playerData.upgradeSpeedLevel;
        }
        else if (type == UpgradeType.Cooldown)
        {
            currentUpgradeLv = DataManager.Instance.playerData.upgradeCooldownLevel;
        }
        Setup();
    }

    public void Setup() {
        for (int i = 0; i < levelColumn.Count; i++) {
            if (i <= currentUpgradeLv)
                levelColumn[i].SetActive(true);
        }
        priceTxt.text = upgradeConfig.upgradeCost[currentUpgradeLv].ToString();
    }
}
