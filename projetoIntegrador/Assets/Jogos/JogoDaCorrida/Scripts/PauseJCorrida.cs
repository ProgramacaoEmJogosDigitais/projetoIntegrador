using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseJCorrida : MonoBehaviour
{
    public GameObject panelPause;
    public bool gamePaused;
    public Button bt_pause;
    public Text time_txt;
    private float timeLeval;

    private void Start()
    {
        panelPause.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.P) && gamePaused == false) //se o jogo nao tive pausado
        {
            Pause();
        }
        else if(Input.GetKey(KeyCode.P) && gamePaused)//se o jogo tiver pausado
        {
            NoPause();
        }
    }
    public void Pause() //aciona o pause
    {
        Time.timeScale = 0.0f;
        gamePaused = true;
        panelPause.gameObject.SetActive(true);
        bt_pause.gameObject.SetActive(false);

    }
    
    public void NoPause() //tira do pause
    {
        gamePaused = false;
        panelPause.gameObject.SetActive(false);
        bt_pause.gameObject.SetActive(true);
        Time.timeScale = 1f;
        for(int i = 0; i < 10; i++)
        {

        }
        /*Time.timeScale = 1f;
        gamePaused = false;
        panelPause.gameObject.SetActive(false);
        bt_pause.gameObject.SetActive(true);*/           
    }
}
