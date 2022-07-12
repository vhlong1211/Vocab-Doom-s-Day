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

    public SoundInfor monsterGrowl1;
    public SoundInfor monsterGrowl2;
    public SoundInfor monsterGrowl3;
    public SoundInfor monsterGrowl4;
    public SoundInfor monsterGrowl5;
    public SoundInfor monsterGrowl6;


    [HideInInspector]
    public float soundVolume;
    [HideInInspector]
    public float musicVolume;

    void Awake()
    {
        BackgroundSound = gameObject.AddComponent<AudioSource>();
        SoundOne = gameObject.AddComponent<AudioSource>();
        soundVolume = 1;
        musicVolume = 1;
    }

    public void StopBgMusic(){
        BackgroundSound.Stop();
    }

    public void PlayBackgroundSound(SoundInfor infor = null, bool loop = true)
    {
        if (infor.clip == null)  return;
        BackgroundSound.clip = infor.clip;
        BackgroundSound.volume = infor.volume * musicVolume;
        BackgroundSound.loop = loop;
        BackgroundSound.Play();
    }

    public void PlaySoundOneShot(SoundInfor infor)
    {
        if (infor.clip == null)
            return;
        SoundOne.clip = infor.clip;
        SoundOne.volume = infor.volume * soundVolume;
        SoundOne.PlayOneShot(infor.clip);
    }

    public void PlayMonsterGrowl() {
        int rd = UnityEngine.Random.Range(1, 7);
        if (rd == 1)
        {
            PlaySoundOneShot(monsterGrowl1);
        }
        else if (rd == 2) {
            PlaySoundOneShot(monsterGrowl2);
        }
        else if (rd == 3)
        {
            PlaySoundOneShot(monsterGrowl3);
        }
        else if (rd == 4)
        {
            PlaySoundOneShot(monsterGrowl4);
        }
        else if (rd == 5)
        {
            PlaySoundOneShot(monsterGrowl5);
        }
        else if (rd == 6)
        {
            PlaySoundOneShot(monsterGrowl6);
        }
    }


}



[Serializable]
public class SoundInfor
{
    public AudioClip clip;
    [Range(0, 1)]
    public float volume = 1;
}

