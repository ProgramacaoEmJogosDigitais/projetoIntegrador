using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlleMusic : MonoBehaviour
{
    public Slider music;
    public AudioSource sound;
    void Start()
    {
        music.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        sound.GetComponent<AudioSource>().volume = music.value;
    }
}
