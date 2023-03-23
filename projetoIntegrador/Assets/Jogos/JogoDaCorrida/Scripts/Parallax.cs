using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Image background;
    public float speed;
    public float score; // pontua��o do jogador
    public TextMeshProUGUI scoreText; // refer�ncia ao componente Text que exibe a pontua��o
    [SerializeField] private float baseSpeed; // pontua��o do jogador
    [SerializeField] private float speedIncrease; // pontua��o do jogador

    private float width = 1920;
    private void Start()
    {
        //record = PlayerPrefs.GetFloat("HighScore");
        score = 0f;
    }
    private void Update()
    {
        MoveBackground();

        score += Time.deltaTime; // incrementa a pontua��o com base no tempo decorrido
        scoreText.text = score.ToString("0"); // atualiza o componente Text com a nova pontua��o

        float newSpeed = baseSpeed + (score * speedIncrease);
        speed = newSpeed;

    }
    /*PlayerPrefs.SetFloat("HighScore", score);
    scoreText.text = "Score: " + score;
    scoreText.text = score + "/" + record;*/

    private void MoveBackground()
    {
        // Movimenta��o da imagem
        transform.Translate(- speed * Time.deltaTime, 0, 0);

        // Se a imagem j� saiu da tela, troca de posi��o pro lado contr�rio
        if (transform.localPosition.x <= -width)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + width * 2, 0, 0);
        }
    }
}
