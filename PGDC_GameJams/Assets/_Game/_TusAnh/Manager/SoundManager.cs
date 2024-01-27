using System;
using System.Collections;
using System.Collections.Generic;
using _Game._TusAnh.SOs;
using UnityEngine;
using UnityEngine.UIElements;


public enum MusicID
{
    BackGroundMusic
}

public enum FxID
{
    Click
}
public class SoundManager : GenericSingleton<SoundManager>

{
    public PlayerSoundData soundData;
    public AudioSource SfxSource;
    public AudioSource MusicSource;

    public void Awake()
    {
        MusicSource = gameObject.AddComponent<AudioSource>();
        MusicSource.loop = true;
        SfxSource = gameObject.AddComponent<AudioSource>();
        SfxSource.loop = false;
    }

    public void Start()
    {
        ChangeMusic(MusicID.BackGroundMusic);
        PlayMusic(true);
    }

    public void ChangeMusic(MusicID musicID)
    {
        MusicSource.clip = soundData.BackGroundMusic[(int)musicID];
    }
    public void PlayMusic(bool play)
    {
        if (play)
        {
          
            MusicSource.Play();
        }
        else
        {
            MusicSource.Stop();
        }
    }
    public void PlayFx(FxID ID)
    {
       SfxSource.PlayOneShot(soundData.Sfx[(int)ID]);
    }

    public void PlayFxClicked()
    {
        PlayFx(FxID.Click);
    }
    
}
