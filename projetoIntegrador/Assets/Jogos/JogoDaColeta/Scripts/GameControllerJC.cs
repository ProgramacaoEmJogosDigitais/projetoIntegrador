using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerJC : MonoBehaviour
{
    public GameObject Objects;
    public static int objetosPerdidosParaGameOver = 3;
    public TextMeshProUGUI score_txt;
    PlayerColeta playerColeta;

    void Start()
    {
        StartCoroutine(GenerateObject());
        Score();
    }

    IEnumerator GenerateObject()
    {
        while (true)
        {
            float x = Random.Range(-8f, 8f);
            float y = 7f;
            Vector2 initialPosition = new Vector2(x, y);
            Instantiate(Objects, initialPosition, Quaternion.identity);
            yield return new WaitForSeconds(2.5f);
        }
    }
    public void Score()
    {
        score_txt.text = "Pontuação:" + playerColeta.points.ToString();
    }
    public static void GameOver()
    {
        // Exibir a tela de game over
        SceneManager.LoadScene("GameOver");
    }
}