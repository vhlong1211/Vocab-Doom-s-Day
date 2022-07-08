using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager m_Instance;
    public static PlayerManager Instance
    {
        get
        {
            return m_Instance;
        }
    }
    private void Awake()
    {
        if (m_Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public PlayerScriptable playerConfig;
    public PlayerController player;
    //[HideInInspector]
    public int health;
    //[HideInInspector]
    public float bulletSpeed;
    //[HideInInspector]
    public float speed;
    //[HideInInspector]
    public float cooldown1;
    //[HideInInspector]
    public float cooldown2;
    //[HideInInspector]
    public float cooldown3;
    //[HideInInspector]
    public float cooldown4;

    [HideInInspector]
    public char chosenChar;
    [HideInInspector]
    public bool isDead = false;
    [HideInInspector]
    public bool isStartGame = false;
    [HideInInspector]
    public int goldCollected;


    public void ResetParam() {
        player.agent.enabled = false;
        player.transform.position = new Vector3(70, 0, 74);        
        player.transform.eulerAngles = new Vector3(0, 0, 0);
        player.isCasting = false;
        player.agent.enabled = true;
        player.agent.SetDestination(player.transform.position);
        health = 20;
        isDead = false;
        chosenChar = 'a';
        goldCollected = 0;
    }

    public void InitPlayerStat() {
        health = playerConfig.health + playerConfig.buffHealthAmount * DataManager.Instance.playerData.upgradeHealthLevel;
        speed = playerConfig.speed + playerConfig.buffSpeedAmount * DataManager.Instance.playerData.upgradeSpeedLevel;
        bulletSpeed = playerConfig.bulletSpeed + playerConfig.buffBulletAmount * DataManager.Instance.playerData.upgradeAtkLevel;
        cooldown1 = playerConfig.skill1Cooldown - playerConfig.buffCooldownAmount * DataManager.Instance.playerData.upgradeCooldownLevel;
        cooldown2 = playerConfig.skill2Cooldown - playerConfig.buffCooldownAmount * DataManager.Instance.playerData.upgradeCooldownLevel;
        cooldown3 = playerConfig.skill3Cooldown - playerConfig.buffCooldownAmount * DataManager.Instance.playerData.upgradeCooldownLevel;
        cooldown4 = playerConfig.skill4Cooldown - playerConfig.buffCooldownAmount * DataManager.Instance.playerData.upgradeCooldownLevel;

    }
}
