using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTut : MonoBehaviour
{
    public CanvasStartScreen canvasStartScreen;
    public void OnOpen()
    {
        gameObject.SetActive(true);
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }

    public void OnBackClick()
    {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        OnClose();
        canvasStartScreen.OnOpen();
    }
}
