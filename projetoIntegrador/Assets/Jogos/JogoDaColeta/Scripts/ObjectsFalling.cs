using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsFalling : MonoBehaviour

{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Destruir o objeto que caiu
            Destroy(gameObject);

            // Aumentar a pontuação do jogador
            //PointsCount.IncreaseScore();
        }
    }

    void Update()
    {
        if (transform.position.y < -6f)
        {
            // Destrua o objeto que caiu
            Destroy(gameObject);

            // Aumente o número de objetos perdidos do jogador
            //PlayerColeta.MissingObject();
        }
    }
}
