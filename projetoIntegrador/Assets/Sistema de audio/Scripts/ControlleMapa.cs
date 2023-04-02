using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControlleMapa : MonoBehaviour
{
    // Start is called before the first frame updat

    private float volumeMusic;
    public Slider volumeSlider;
    public GameObject objMusic;
    private AudioSource audioSource;

    private void Start()
    {
        objMusic = GameObject.FindWithTag("GameMusic");
        audioSource = objMusic.GetComponent<AudioSource>();
        volumeMusic = PlayerPrefs.GetFloat("volume");
        volumeMusic = audioSource.volume;
        volumeSlider.value = volumeMusic;    
    }
    private void Update()
    {
        audioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volume", volumeMusic);
    }
  









}
