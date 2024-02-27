using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    // Volume configura��o inicial
    public static float volume, volumeEffect;

    // Refer�ncia ao slider no painel de controle de volume
    public Slider musicSlider, effectSlider;

    private void Start()
    {
        // Configura o valor inicial do slider
        musicSlider.value = PlayerPrefs.GetFloat("volume", volume);
        effectSlider.value = PlayerPrefs.GetFloat("volumeEffect", volumeEffect);
        SetVolume(volume, volumeEffect); // Configura o volume ao iniciar
    }

    public void Update()
    {
        volume = musicSlider.value;
        volumeEffect = effectSlider.value;
        Debug.Log("music volume:" + volume);
        Debug.Log("music Effectvolume:" + volumeEffect);
    }

    public void SetVolume(float value, float effectValue)
    {
        // Define o volume, salva no PlayerPrefs e atualiza o slider
        volume = value;
        volumeEffect = effectValue;
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.SetFloat("EffectVolume", effectValue);
        //AudioListener.volume = volume;
        //AudioListener.volume = volumeEffect;
    }
}