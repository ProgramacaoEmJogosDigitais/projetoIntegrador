using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudio;
    [SerializeField] private AudioSource sfxAudio;

    public static AudioPlayer instance;

    private void Awake()
    {
        if(instance == null)
        instance = this;
    }

    public void PlayBGM(AudioClip music)
    {
        bgmAudio.clip = music;
        bgmAudio.Play();
    }

    public void StopBGM()
    {
        bgmAudio.Stop();
    }

    public void PlaySFX(AudioClip soundEfect)
    {
        sfxAudio.PlayOneShot(soundEfect);
    }

    public void StopSFX()
    {
        sfxAudio.Stop();
    }
}
