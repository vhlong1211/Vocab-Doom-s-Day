using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLoadingScreen : MonoBehaviour
{   
    private static CanvasLoadingScreen m_Instance;

    public static CanvasLoadingScreen Instance
    {
        get
        {
            return m_Instance;
        }
    }

    public TimerClock timerClock;
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

    public Slider loadingSlider; 

    public void UpgradeValue()
    {   
        if(loadingSlider.value > 0)
            loadingSlider.value -= Time.deltaTime * Random.Range(5,10) ;
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
        loadingSlider.value = 1;
        timerClock.OnOpen();
    }

    public void OnOpen()
    {
        gameObject.SetActive(true);
    }
}
