using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColeta : MonoBehaviour
{
    public float velocidade = 5f;
    static int missingObjects = 0; 

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
        if (missingObjects >= GameOver.objetosPerdidosParaGameOver)
        {
            // Game over!
            GameOver.gameOver();
        }
    }
}