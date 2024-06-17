using System.Collections.Generic;
using UnityEngine;

namespace MaronByteStudio.Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] Dictionary<MusicType, string> MusicFiles;
        [Range(0, 1)][SerializeField] float MusicVolume;
        [SerializeField] AudioSource MusicSource;
        [SerializeField] AudioSource SfxSource;

        internal void PlayMusic(MusicType musicType)
        {
            AudioClip clip = Resources.Load<AudioClip>(MusicFiles[musicType]);
            if (clip == null)
            {
                Debug.LogError($"Could not find audio clip {MusicFiles[musicType]} for {musicType}");
                return;
            }
            MusicSource.clip = clip;
            MusicSource.volume = MusicVolume;
            MusicSource.Play();
        }

        internal void PlaySfx(string clipName)
        {
            AudioClip clip = Resources.Load<AudioClip>(clipName);
            SfxSource.clip = clip;
            SfxSource.Play();
        }

        internal void Refresh()
        {
            MusicSource.mute = Settings.MuteMusic;
            SfxSource.mute = Settings.MuteSfx;
        }
    }

    public enum MusicType
    {
        Menu,
        Game
    }
}
