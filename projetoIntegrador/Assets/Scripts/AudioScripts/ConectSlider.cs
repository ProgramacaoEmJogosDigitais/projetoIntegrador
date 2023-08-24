using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ConectSlider : MonoBehaviour
{
    //[SerializeField] private AudioMixer masterMixer;

    [SerializeField] private Slider bgmSlider;
    //[SerializeField] private Slider sfxSlider;
    private void Start()
    {
        //VolumeBGM();
        //VolumeSFX();
    }
    /*
    public void VolumeBGM()
    {
        SetFloat("BGM", bgmSlider.value);
    }*/
    /*
    public void VolumeSFX()
    {
        masterMixer.SetFloat("SFX", sfxSlider.value);
    }*/
}