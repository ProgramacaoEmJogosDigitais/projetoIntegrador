using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAudioSistem : MonoBehaviour
{
    // Start is called before the first frame update
   public void LoadsScenas(string scenes)
    {
        SceneManager.LoadScene(scenes);

    }
}
