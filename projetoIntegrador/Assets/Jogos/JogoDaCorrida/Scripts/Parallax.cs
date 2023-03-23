using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Image background;
    public float speed;
    public float score; // pontuação do jogador
    public TextMeshProUGUI scoreText; // referência ao componente Text que exibe a pontuação
    [SerializeField] private float baseSpeed; // pontuação do jogador
    [SerializeField] private float speedIncrease; // pontuação do jogador

    private float width = 1920;
    private void Start()
    {
        //record = PlayerPrefs.GetFloat("HighScore");
        score = 0f;
    }
    private void Update()
    {
        MoveBackground();

        score += Time.deltaTime; // incrementa a pontuação com base no tempo decorrido
        scoreText.text = score.ToString("0"); // atualiza o componente Text com a nova pontuação

        float newSpeed = baseSpeed + (score * speedIncrease);
        speed = newSpeed;

    }
    /*PlayerPrefs.SetFloat("HighScore", score);
    scoreText.text = "Score: " + score;
    scoreText.text = score + "/" + record;*/

    private void MoveBackground()
    {
        // Movimentação da imagem
        transform.Translate(- speed * Time.deltaTime, 0, 0);

        // Se a imagem já saiu da tela, troca de posição pro lado contrário
        if (transform.localPosition.x <= -width)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + width * 2, 0, 0);
        }
    }
}
