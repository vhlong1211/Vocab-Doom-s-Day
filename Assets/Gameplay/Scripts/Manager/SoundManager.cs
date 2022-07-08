using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
            }

            return instance;
        }
    }

    [HideInInspector] public AudioSource BackgroundSound;

    [HideInInspector] public AudioSource SoundOne;

    public static AudioClip CurrentBgClip;

    public SoundInfor MenuBgSound;
    public SoundInfor GameplaySound;
    public SoundInfor clickSound;
    public SoundInfor shotSound;
    public SoundInfor Skill1Sound;
    public SoundInfor Skill2Sound;
    public SoundInfor Skill3Sound;
    public SoundInfor WinSound;
    public SoundInfor HealingSound;
    public SoundInfor BuffSpeedSound;
    public SoundInfor BlinkSound;
    public SoundInfor HitSound1;
    public SoundInfor HitSound2;
    public SoundInfor UpgradeSound;
    public SoundInfor ShieldSwingSound;
    public SoundInfor openBookSound;

    void Awake()
    {
        BackgroundSound = gameObject.AddComponent<AudioSource>();
        SoundOne = gameObject.AddComponent<AudioSource>();
    }

    public void StopBgMusic(){
        BackgroundSound.Stop();
    }

    public void PlayBackgroundSound(SoundInfor infor = null, bool loop = true)
    {
        if (infor.clip == null)  return;
        BackgroundSound.clip = infor.clip;
        BackgroundSound.volume = infor.volume;
        BackgroundSound.loop = loop;
        BackgroundSound.Play();
    }

    public void PlaySoundOneShot(SoundInfor infor)
    {
        if (infor.clip == null)
            return;
        SoundOne.clip = infor.clip;
        SoundOne.volume = infor.volume;
        SoundOne.PlayOneShot(infor.clip);
    }


}



[Serializable]
public class SoundInfor
{
    public AudioClip clip;
    [Range(0, 1)]
    public float volume = 1;
}

