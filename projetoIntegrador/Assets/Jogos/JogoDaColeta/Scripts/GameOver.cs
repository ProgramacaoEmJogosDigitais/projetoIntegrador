using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static int objetosPerdidosParaGameOver = 3;

    public static void gameOver()
    {
        // Exibir a tela de game over
        SceneManager.LoadScene("GameOver");
    }
}
