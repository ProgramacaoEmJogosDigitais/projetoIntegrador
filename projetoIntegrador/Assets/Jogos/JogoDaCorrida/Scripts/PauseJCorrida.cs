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

    private void Start()
    {
        pressButtonNoPause = false;
        panelPause.SetActive(false);
        time = 3.0f;
        InvokeRepeating("NoPause", 0.0f, 0.1f);
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

    private void Update()
    {
        if (time > 0.0f && gamePaused && pressButtonNoPause)
        {
            time -= 0.1f;
            txt_Countdown.text = time.ToString("F0");
        }
        else
        {
            CancelInvoke();
            txt_Countdown.gameObject.SetActive(false);
            gamePaused = false;
            Time.timeScale = 1f;
            time = 3.0f;
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
        //gamePaused = false;
        panelPause.gameObject.SetActive(false);
        bt_pause.gameObject.SetActive(true);
        txt_Countdown.gameObject.SetActive(true);
        pressButtonNoPause = true;
        //if (time > 0.0f && gamePaused)
        //{
        //    time -= 0.1f;
        //    txt_Countdown.text = time.ToString("F0");
        //}
        //else
        //{
        //    CancelInvoke();
        //    txt_Countdown.gameObject.SetActive(false);

        //    gamePaused = false;

        //    Time.timeScale = 1f;
        //}
        
        /*Time.timeScale = 1f;
        gamePaused = false;
        panelPause.gameObject.SetActive(false);
        bt_pause.gameObject.SetActive(true);*/
    }
}
