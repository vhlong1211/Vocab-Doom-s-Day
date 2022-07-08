using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChooseMap : MonoBehaviour
{

    public CanvasLoadingScreen canvasLoadingScreen;
    public CanvasPlayoptionScreen playoptionScreen;
    public CanvasBookScreen bookScreen;
    public Swiper swiper;
    public List<GameObject> lockerList = new List<GameObject>();

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
        Setup();
    }

    public void OnPlayClick() {
        if (swiper.currentPage > DataManager.Instance.playerData.mapLevel) return;
        canvasLoadingScreen.OnOpen();
        SoundManager.Instance.StopBgMusic();
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        LoadingManager.Instance.LoadDictionary(swiper.currentPage);
        GameManager.Instance.currentLevel = MathUtility.IndexToLevelType(swiper.currentPage);
        Debug.Log("swiper:" + swiper.currentPage);
        gameObject.SetActive(false);
    }

    public void OnReadClick() {
        if (swiper.currentPage > DataManager.Instance.playerData.mapLevel) return;
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.openBookSound);
        bookScreen.OnOpen();
        bookScreen.OpenBook(swiper.currentPage);
    }

    public void OnBack()
    {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        gameObject.SetActive(false);
        playoptionScreen.OnOpen();
    }

    public void Setup() {
        int mapLevel = DataManager.Instance.playerData.mapLevel;
        for (int i = 0; i < lockerList.Count; i++) {
            if (i <= mapLevel) {
                lockerList[i].SetActive(false);
            }
        }
    }

}
