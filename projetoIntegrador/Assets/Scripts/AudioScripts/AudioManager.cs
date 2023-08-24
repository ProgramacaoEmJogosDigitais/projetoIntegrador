using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //public List<AudioClip> levelSFXList;
    public List<AudioClip> BGMList;
    private List<AudioClip> atualList;

    private void Start()
    {    
        /*
        for (int i = 0; i < BGMList.Count; i++)
        {
            int indexmusic = Random.Range(0, BGMList.Count);            
            Debug.Log(indexmusic);
            atualList.Add(BGMList[indexmusic]);
        }*/

        int indexmusic = Random.Range(0, BGMList.Count);
        for (int i = 0; i < BGMList.Count; i++)
        {
            if (BGMList[i] == BGMList[indexmusic])
            {
                AlterationsMusic.Instance.StartCoroutine(AlterationsMusic.Instance.PlayMusic(BGMList[i]));
                //AlterationsMusic.Instance.PlayMusic(BGMList[i]);
            }
        }
    }
}
