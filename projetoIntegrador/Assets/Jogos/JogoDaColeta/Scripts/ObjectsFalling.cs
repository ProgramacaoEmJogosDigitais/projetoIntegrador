using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsFalling : MonoBehaviour
{
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
        if (transform.position.y < -6f)
        {
            // Destrua o objeto que caiu
            Destroy(gameObject);

            // Aumente o n�mero de objetos perdidos do jogador
            PlayerColeta.MissingObject();
        }
    }
}
