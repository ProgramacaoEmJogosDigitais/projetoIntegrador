using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerColeta : MonoBehaviour
{
    public float velocidade = 5f;
    public static int missingObjects = 0;

    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        Vector2 movimento = new Vector2(movimentoHorizontal, movimentoVertical);

        transform.Translate(Time.deltaTime * velocidade * movimento);
    }

    public static void MissingObject()
    {
        missingObjects++;
        if (missingObjects >= GameControllerJC.lostObjectsForGameOver)
        {
            // Game over!
            GameControllerJC.GameOver();
        }
    }
}