using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LevelManager: MonoBehaviour
{

    public string levelName; // Nome da fase
    public AudioClip levelBGM;
    public AudioClip[] levelSFXList;

    private void Start()
    {
        AudioPlayer.Instance.SetLevelAudioData(levelName, levelBGM, levelSFXList);
        AudioPlayer.Instance.PlayBGMForLevel(levelName);
    }
}
