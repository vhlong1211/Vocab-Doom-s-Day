using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Popup_Setting : MonoBehaviour
{
    private static Popup_Setting instance;

    public static Popup_Setting Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Popup_Setting>();
            }

            return instance;

        }
    }

    public Slider soundSlider;
    public Slider musicSlider;

    public void OnApply() {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        SoundManager.Instance.soundVolume = soundSlider.value;
        SoundManager.Instance.musicVolume = musicSlider.value;
        SoundManager.Instance.StopBgMusic();
        SoundManager.Instance.PlayBackgroundSound(SoundManager.Instance.MenuBgSound);
        gameObject.SetActive(false);
    }

    public void OnOpen() {
        gameObject.SetActive(true);
    }

    public void OnClose() {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        gameObject.SetActive(false);
    }
}
