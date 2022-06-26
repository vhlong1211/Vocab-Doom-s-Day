using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDieScreen : MonoBehaviour
{

    public CanvasChooseMap canvasChooseMapScreen;
    public void OnOpen() {
        gameObject.SetActive(true);
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }

    public void OnRestart() { 
    
    }

    public void OnBack() {
        PlayerManager.Instance.ResetParam();
        OnClose();
        canvasChooseMapScreen.OnOpen();
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        SoundManager.Instance.PlayBackgroundSound(SoundManager.Instance.MenuBgSound);
    }
}
