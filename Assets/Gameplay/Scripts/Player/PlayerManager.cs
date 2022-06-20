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

    public PlayerController player;
    public int health = 20;
    [HideInInspector]
    public char chosenChar;
    [HideInInspector]
    public bool isDead = false;

    public void ResetParam() {
        player.agent.enabled = false;
        player.transform.position = new Vector3(70, 0, 74);        
        player.transform.eulerAngles = new Vector3(0, 0, 0);
        health = 20;
        isDead = false;
        chosenChar = 'a';
        player.isCasting = false;
        player.agent.enabled = true;
        player.agent.SetDestination(player.transform.position);
    }
}
