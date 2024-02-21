using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    // Volume configuração inicial
    public static float volume, volumeEffect;

    // Referência ao slider no painel de controle de volume
    public Slider musicSlider, effectSlider;

    private void Start()
    {
        // Configura o valor inicial do slider
        musicSlider.value = PlayerPrefs.GetFloat("volume", volume);
        effectSlider.value = PlayerPrefs.GetFloat("volumeEffect", volumeEffect);
        SetVolume(volume); // Configura o volume ao iniciar
        SetVolume(volumeEffect);
    }

    public void Update()
    {
        volume = musicSlider.value;
        volumeEffect = effectSlider.value;
        FindObjectOfType<Slider>().value = volume;
        FindObjectOfType<Slider>().value = volumeEffect;
       
    }

    public void SetVolume(float value)
    {
        // Define o volume, salva no PlayerPrefs e atualiza o slider
        volume = value;
        volumeEffect = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.SetFloat("EffectVolume", value);
        //AudioListener.volume = volume;
        //AudioListener.volume = volumeEffect;
    }
}