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
    public TMP_Text pointsText;
    private MovimentPlayer movimentPlayer;

    private void Awake()
    {
        Time.timeScale = 1;
        movimentPlayer = FindObjectOfType<MovimentPlayer>();
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

}
