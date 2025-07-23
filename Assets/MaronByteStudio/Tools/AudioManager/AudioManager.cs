using MaronByteStudio;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    protected override bool PersistBetweenScenes => true;
    
    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private AudioSource SfxSource;

    internal void PlayMusic(AudioClip clip)
    {
        MusicSource.Play();
    }

    internal void StopMusic()
    {
        MusicSource.Pause();
    }

    internal void PlaySfx(AudioClip clip)
    {
        SfxSource.PlayOneShot(clip);
    }
}
