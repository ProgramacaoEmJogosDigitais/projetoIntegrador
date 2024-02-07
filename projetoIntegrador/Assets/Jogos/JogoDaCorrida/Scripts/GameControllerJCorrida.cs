using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class GameControllerJCorrida : MonoBehaviour
{
    public bool gameOver;
    public GameObject panelGameOver;
    public GameObject panelOptions;
    public TMP_Text pointsText;
    public AudioSystem audioSystemScript;
    private MovimentPlayer movimentPlayer;
    private PauseJCorrida pauseJCorridaScript;

    private void Awake()
    {
        Time.timeScale = 1;
        movimentPlayer = FindObjectOfType<MovimentPlayer>();
        pauseJCorridaScript = FindObjectOfType<PauseJCorrida>();
    }

    private void Start()
    {
        audioSystemScript.PlaySound("BackGameCorrida");
        audioSystemScript.SetLooping(true);

        if (pauseJCorridaScript.gamePaused)
        {
            //musica precisa parar quando tiver pausado

        }
    }
    private void FixedUpdate()
    {
        if (gameOver) //verifica se perdeu
        {
            Time.timeScale = 0;
            pointsText.text = movimentPlayer.distance.ToString("F0");
            panelGameOver.SetActive(true);
        }
    }

    public void OpenOptions()
    {
        panelOptions.gameObject.SetActive(true);
    }
    
    public void ExitOptions()
    {
        panelOptions.gameObject.SetActive(false);
    }

    void RestartGame()
    {
        
    }


}
