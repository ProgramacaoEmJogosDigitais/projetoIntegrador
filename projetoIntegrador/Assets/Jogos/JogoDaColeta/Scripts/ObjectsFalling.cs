using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsFalling : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Destrua o objeto que caiu
            Destroy(gameObject);

            // Aumente a pontua��o do jogador
            //Pontuacao.aumentarPontuacao();
        }
    }

    void Update()
    {
        if (transform.position.y < -6f)
        {
            // Destrua o objeto que caiu
            Destroy(gameObject);

            // Aumente o n�mero de objetos perdidos do jogador
            //PlayerColeta.objetoPerdido();
        }
    }
}
