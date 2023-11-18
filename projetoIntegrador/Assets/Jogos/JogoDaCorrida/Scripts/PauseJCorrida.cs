using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
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

    private void Awake()
    {
        pressButtonNoPause = false;
    }
    private void Start()
    {
        panelPause.SetActive(false);
        time = 3.0f;
    }

    private void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.P)) Time.timeScale = Time.timeScale == 1.0f ? 0.0f : 1.0f;
        //Debug.Log(Time.timeScale);

        //if (Input.GetKey(KeyCode.P) && gamePaused == false) //se o jogo nao tive pausado
        //{
        //    Pause();
        //}
        //else if (Input.GetKey(KeyCode.P) && gamePaused)//se o jogo tiver pausado
        //{
        //    NoPause();
        //}
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

        if (Input.GetKey(KeyCode.P) && gamePaused == false) //se o jogo nao tive pausado
        {
            //Pause();

            Time.timeScale = 0.0f;
            //gamePaused = true;
            panelPause.gameObject.SetActive(true);
            bt_pause.gameObject.SetActive(false);
        }

        else if (Input.GetKey(KeyCode.P) && gamePaused)//se o jogo tiver pausado
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
        panelPause.gameObject.SetActive(false);
        bt_pause.gameObject.SetActive(true);
        txt_Countdown.gameObject.SetActive(true);
        pressButtonNoPause = true;

        
    }
    
}
