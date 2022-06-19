using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStartScreen : MonoBehaviour
{
    private static CanvasStartScreen m_Instance;

    public static CanvasStartScreen Instance
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

    public CanvasLoadingScreen canvasLoadingScreen;
    public CanvasPlayoptionScreen canvasPlayOptionScreen;
    public void OnStartClick()
    {
        //canvasLoadingScreen.OnOpen();
        //LoadingManager.Instance.LoadDictionary();
        //gameObject.SetActive(false);

        canvasPlayOptionScreen.OnOpen();
        gameObject.SetActive(false);
    }
}
