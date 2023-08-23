using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LevelManager: MonoBehaviour
{

    public string levelName; // Nome da fase
    public AudioClip levelBGM;
    public AudioClip[] levelSFXList;
    public AudioClip[] menuBGMList;
    public AudioClip[] mapBGMList;
    public AudioClip[] atualList;

    private void Start()
    {
            int indexmusic = Random.Range(0, menuBGMList.Length);
            AudioPlayer.Instance.SetLevelAudioData(levelName, menuBGMList[indexmusic], levelSFXList);
            Debug.Log(indexmusic);
            AudioPlayer.Instance.PlayBGMForLevel(levelName);
    }


}
