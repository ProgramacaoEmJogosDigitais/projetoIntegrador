using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseJCorrida : MonoBehaviour
{
    public GameObject panelPause;
    public bool gamePaused;
    public bool pressButtonNoPause;
    public Button bt_pause;
    public float time;
    public TMP_Text txt_Countdown;
    public bool pauseWithP;

    private void Awake()
    {
        pressButtonNoPause = false;
        pauseWithP = true;
    }
    private void Start()
    {
        panelPause.SetActive(false);
        time = 3.0f;
    }

    private void Update()//erro para o botao "p"
    {
        if (pressButtonNoPause)
        {
            time -= 0.01f;
            txt_Countdown.text = time.ToString("F0");
            if (time <= 0.0f)
            {
                pressButtonNoPause=false;
                txt_Countdown.gameObject.SetActive(false);
                gamePaused = false;
                Time.timeScale = 1f;
                time = 3.0f;

            }
        }

        if (Input.GetKeyDown(KeyCode.P) && pauseWithP) //se o jogo nao tive pausado
        {
            Time.timeScale = 0.0f;
            panelPause.gameObject.SetActive(true);
            bt_pause.gameObject.SetActive(false);
            pauseWithP = false;
            gamePaused = true;
        }

        else if (Input.GetKeyDown(KeyCode.P) && gamePaused)//se o jogo tiver pausado
        {
            gamePaused = false;
            pauseWithP = true;
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
        panelPause.gameObject.SetActive(false);
        bt_pause.gameObject.SetActive(true);
        txt_Countdown.gameObject.SetActive(true);
        pressButtonNoPause = true;

        
    }
    
}
