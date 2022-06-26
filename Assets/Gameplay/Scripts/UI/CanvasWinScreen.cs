using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasWinScreen : MonoBehaviour
{
    public CanvasChooseMap canvasChooseMapScreen;
    // Start is called before the first frame update
    public void OnOpen()
    {
        gameObject.SetActive(true);
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }

    public void OnRestart()
    {

    }

    public void OnNext()
    {
        PlayerManager.Instance.ResetParam();
        OnClose();
        canvasChooseMapScreen.OnOpen();
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        SoundManager.Instance.PlayBackgroundSound(SoundManager.Instance.MenuBgSound);
    }
}
