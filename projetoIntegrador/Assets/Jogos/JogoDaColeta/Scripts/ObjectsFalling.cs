using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsFalling : MonoBehaviour
{
    public static int points = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Destruir o objeto que caiu
            Destroy(gameObject);

            // Aumentar a pontuação do jogador
            points++;
            DataFish.fishPoints = points;
            Debug.Log("pontos:" + points);
        }
    }

    void Update()
    {
        if (transform.position.y < -6f)
        {
            // Destrua o objeto que caiu
            Destroy(gameObject);

            // Aumente o número de objetos perdidos do jogador
            PlayerColeta.MissingObject();
        }
    }
}
