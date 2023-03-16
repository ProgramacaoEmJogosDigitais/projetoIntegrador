using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerColeta : MonoBehaviour
{
    public float velocidade = 5f;
    static int missingObjects = 0;
    public int points = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Destruir o objeto que caiu
            Destroy(gameObject);

            // Aumentar a pontua��o do jogador
            points++;
        }
    }

    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        Vector2 movimento = new Vector2(movimentoHorizontal, movimentoVertical);

        transform.Translate(movimento * velocidade * Time.deltaTime);
    }

    public static void MissingObject()
    {
        missingObjects++;
        if (missingObjects >= GameControllerJC.objetosPerdidosParaGameOver)
        {
            // Game over!
            GameControllerJC.GameOver();
        }
    }
}