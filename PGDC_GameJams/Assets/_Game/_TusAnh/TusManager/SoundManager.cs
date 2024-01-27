using System;
using System.Collections;
using System.Collections.Generic;
using _Game._TusAnh.SOs;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;


public enum MusicID
{
    BackGroundMusic,
    BattleMusic
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

    public AudioMixerGroup[] AudioMixerGroups;
    public AudioMixer mixer;
    
    public Slider sfx;
    public Slider music;
    public Slider master;
    
    
    public void Awake()
    {
        MusicSource = gameObject.AddComponent<AudioSource>();
        MusicSource.loop = true;
        MusicSource.outputAudioMixerGroup = AudioMixerGroups[1];
        
        SfxSource = gameObject.AddComponent<AudioSource>();
        SfxSource.outputAudioMixerGroup = AudioMixerGroups[2];
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

    public void ValueChangeInSlider( )
    {
        mixer.SetFloat("Master", Mathf.Log10(master.value) * 20);
        mixer.SetFloat("Music", Mathf.Log10(music.value) * 20);
        mixer.SetFloat("SFX", Mathf.Log10(sfx.value) * 20);
    }

  
    
}
