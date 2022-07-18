using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPlayoptionScreen : MonoBehaviour
{
    public CanvasHighscoreScreen canvasHighscoreScreen;
    public CanvasStartScreen canvasStartScreen;
    public CanvasChooseMap canvasChooseMapScreen;
    public CanvasInventoryScreen canvasInventoryScreen;

    
    public void OnOpen()
    {
        gameObject.SetActive(true);
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }

    public void OnMainModeClick() {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        canvasChooseMapScreen.OnOpen();
        gameObject.SetActive(false);
    }

    public void OnHighscoreClick() {
        //SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        canvasHighscoreScreen.OnOpen();
        gameObject.SetActive(false);
    }

    public void OnInventoryClick()
    {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        canvasInventoryScreen.OnOpen();
        gameObject.SetActive(false);
    }

    public void OnCustomClick()
    {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
    }

    public void OnBackClick() {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        OnClose();
        canvasStartScreen.OnOpen();
    }

}
