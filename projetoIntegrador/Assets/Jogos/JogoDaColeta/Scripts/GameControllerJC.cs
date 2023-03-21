using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerJC : MonoBehaviour
{
    public GameObject[] prefabFishs;
    public static int lostObjectsForGameOver = 3;
    public TextMeshProUGUI score_txt;
    public TextMeshProUGUI missScore_txt;
    public float time;

    void Start()
    {
        StartCoroutine(GenerateObject());
    }

    public void Update()
    {
        Score();   
    }

    IEnumerator GenerateObject()
    {
        while (true)
        {
            float x = Random.Range(-8f, 8f);
            float y = 7f;
            Vector2 spawnPosition = new Vector2(x, y);
            Instantiate(prefabFishs[Random.Range(0, prefabFishs.Length)], spawnPosition, Quaternion.identity);
            time = Random.Range(2, 4);
            yield return new WaitForSeconds(time);
        }
    }
    public void Score()
    {
        missScore_txt.text = "peixes caídos: " + PlayerColeta.missingObjects.ToString();
        score_txt.text = "Pontuação: " + FishsFalling.points.ToString();
    }
    public static void GameOver()
    {
        // Exibir a tela de game over
        SceneManager.LoadScene("GameOver");
    }
}