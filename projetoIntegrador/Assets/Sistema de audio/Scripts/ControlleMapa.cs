using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControlleMapa : MonoBehaviour
{
    // Start is called before the first frame updat

   
    public Slider volumeSlider;
    public GameObject objMusic;
    private AudioSource audioSource;

    private void Start()
    {
        objMusic = GameObject.FindWithTag("GameMusic");
        audioSource = objMusic.GetComponent<AudioSource>(); 
        volumeSlider.value = 0;
    }
    private void Update()
    {
        audioSource.volume = volumeSlider.value;
    }









}
