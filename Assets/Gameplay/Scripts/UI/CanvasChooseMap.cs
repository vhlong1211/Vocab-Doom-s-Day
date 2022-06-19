using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChooseMap : MonoBehaviour
{

    public CanvasLoadingScreen canvasLoadingScreen;
    public Swiper swiper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOpen()
    {
        gameObject.SetActive(true);
    }

    public void OnPlayClick() {
        canvasLoadingScreen.OnOpen();
        LoadingManager.Instance.LoadDictionary();
        Debug.Log("swiper:" + swiper.currentPage);
        gameObject.SetActive(false);
    }

}
