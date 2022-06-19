using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMainMenu : UICanvas
{
    private static CanvasMainMenu m_Instance;

    public static CanvasMainMenu Instance
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

    //public Transform startScreen;
    //public Transform loadingScreen;
    public CanvasLoadingScreen canvasLoadingScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartClick() {
        //startScreen.gameObject.SetActive(false);
        //loadingScreen.gameObject.SetActive(true);
        LoadingManager.Instance.LoadDictionary();

    }
}
