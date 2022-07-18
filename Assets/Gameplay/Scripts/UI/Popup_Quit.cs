using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup_Quit : MonoBehaviour
{

    public void OnOpen() {
        gameObject.SetActive(true);
    }

    public void OnClose()
    {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        gameObject.SetActive(false);
    }

    public void OnYes() {
        Application.Quit();
    }
}
