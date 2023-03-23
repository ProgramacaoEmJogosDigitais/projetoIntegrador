using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerColeta : MonoBehaviour
{
    public float playerSpeed = 5f;
    public static int missingObjects = 0;

    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        Vector2 movimento = new Vector2(movimentoHorizontal, 0);
        transform.Translate(Time.deltaTime * playerSpeed * movimento);
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