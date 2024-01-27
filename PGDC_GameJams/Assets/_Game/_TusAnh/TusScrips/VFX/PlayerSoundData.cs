using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace _Game._TusAnh.SOs
{
    [CreateAssetMenu(fileName = "SoundData", menuName = "SoundData", order = 0)]
    public class PlayerSoundData : ScriptableObject
    {
        public List<AudioClip> backGroundMusic;
        public List<AudioClip> sfx;
        public AudioMixer audioMixer;

        public List<AudioClip> BackGroundMusic
        {
            get => backGroundMusic;
            set => backGroundMusic = value;
        }

        public List<AudioClip> Sfx
        {
            get => sfx;
            set => sfx = value;
        }

        public AudioMixer AudioMixer
        {
            get => audioMixer;
            set => audioMixer = value;
        }
    }
}