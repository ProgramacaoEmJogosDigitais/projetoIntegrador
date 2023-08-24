using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterationsMusic : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudio;
    //[SerializeField] private AudioSource sfxAudio;
    public static AlterationsMusic Instance { get; set; }
    public IEnumerator PlayMusic(AudioClip music)
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = music;
        audio.Play();
    }
    /*
    public void PlayMusic(AudioClip music)
    {
        bgmAudio.clip = music;
        bgmAudio.Play();
    }*/
}
