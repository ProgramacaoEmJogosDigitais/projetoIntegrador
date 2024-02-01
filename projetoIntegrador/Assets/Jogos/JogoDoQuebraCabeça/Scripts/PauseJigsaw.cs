using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseJigsaw : MonoBehaviour
{
    public GameObject panelPause;
    public bool gamePaused;
    public bool pressButtonNoPause = false;
    public Button bt_pause;
    public float time;
    public TMP_Text txt_Countdown;
    public bool pauseWithP = true;

    private void Update()
    {
        if (pressButtonNoPause)
        {
            /*if (time <= 0.0f)
            {*/
                pressButtonNoPause = false;
                gamePaused = false;
                Time.timeScale = 1f;
                bt_pause.gameObject.SetActive(true);

            /*}
            else
            {*/
                //counting = true; //nao pode apertar pause de novo;
                pressButtonNoPause = true;
            //}
        }

        if (Input.GetKeyDown(KeyCode.P) && pauseWithP && !pressButtonNoPause) //se o jogo nao tive pausado, ele pode apertar o pause
        {
            Time.timeScale = 0.0f;
            panelPause.gameObject.SetActive(true);
            bt_pause.gameObject.SetActive(false);
            pauseWithP = false;
            gamePaused = true;
        }

        else if (Input.GetKeyDown(KeyCode.P) && gamePaused)//se o jogo tiver pausado, aperta pra despasuar
        {
            gamePaused = false;
            pauseWithP = true;
        }
    }
    public void Pause() //aciona o pause
    {
        Time.timeScale = 0.0f;
    }
    public void NoPause()
    {
        Time.timeScale = 1.0f;
    }

    public void GoMap(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}