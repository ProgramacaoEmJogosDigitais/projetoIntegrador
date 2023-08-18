using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudio;
    [SerializeField] private AudioSource sfxAudio;

    public static AudioPlayer Instance { get; set; }

    private Dictionary<string, LevelAudioData> levelAudioData = new Dictionary<string, LevelAudioData>();

    private bool isBgmPaused = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
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

    public void PauseBGM()
    {
        if (bgmAudio.isPlaying)
        {
            bgmAudio.Pause();
            isBgmPaused = true;
        }
    }

    public void ResumeBGM()
    {
        if (isBgmPaused)
        {
            bgmAudio.UnPause();
            isBgmPaused = false;
        }
    }

    public void PlaySFX(AudioClip soundEffect)
    {
        sfxAudio.PlayOneShot(soundEffect);
    }

    public void StopSFX()
    {
        sfxAudio.Stop();
    }

    public void SetLevelAudioData(string levelName, AudioClip bgm, AudioClip[] sfxList)
    {
        levelAudioData[levelName] = new LevelAudioData
        {
            bgm = bgm,
            sfxList = sfxList
        };
    }

    public void PlayBGMForLevel(string levelName)
    {
        if (levelAudioData.TryGetValue(levelName, out LevelAudioData audioData))
        {
            PlayBGM(audioData.bgm);
        }
    }
}
public class LevelAudioData: MonoBehaviour
{
    public AudioClip bgm;
    public AudioClip[] sfxList;
}
