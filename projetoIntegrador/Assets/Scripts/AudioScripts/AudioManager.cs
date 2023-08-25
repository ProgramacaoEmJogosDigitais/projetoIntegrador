using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    //public List<AudioClip> levelSFXList;
    public List<AudioSource> musicList;
    private List<AudioClip> atualList;
    public static float volume;
    public float volume2;
    public  Slider musicVolume;
    int indexmusic;

    private void Update()
    {
        volume = musicVolume.value;   
      
        musicList[indexmusic].volume = volume;  


    }
    private void Start()
    {
        musicVolume.value = volume;

        StartCoroutine(PlayMusic(musicList));

        //foreach (var item in musicList )
        //{

        //}
        //for (int i = 0; i < BGMList.Count; i++)
        //{
        //    int indexmusic = Random.Range(0, BGMList.Count);            
        //    Debug.Log(indexmusic);
        //    atualList.Add(BGMList[indexmusic]);
        //}

        //for (int i = 0; i < atualList.Count; i++)
        //{

        //      AlterationsMusic.Instance.StartCoroutine(AlterationsMusic.Instance.PlayMusic(atualList[i]));
        //      //AlterationsMusic.Instance.PlayMusic(BGMList[i]);
        //}

       
    }
    public IEnumerator PlayMusic(List <AudioSource> music)
    {
         int index = 0;  
      
        while(true)
        {
            music[index].Play();
            yield return new WaitForSeconds(music[index].clip.length);
         
            index = Random.Range(0, music.Count);
            indexmusic = index;


        }
      
            

       
    }
}
