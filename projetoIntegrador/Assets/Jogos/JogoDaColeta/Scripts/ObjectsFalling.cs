using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsFalling : MonoBehaviour
{
    public float minFallSpeed = 1f;
    public float maxFallSpeed = 1f;
    public static int points = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Destruir o objeto que caiu
            Destroy(gameObject);

            // Aumentar a pontuação do jogador
            points++;
            Debug.Log("pontos:" + points);
        }
    }

    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
        rb.velocity = new Vector2(0f, -fallSpeed);
        Debug.Log ("velocidade q ta caindo" + fallSpeed);

        if (transform.position.y < -4.5f)
        {
            // Destrua o objeto que caiu
            Destroy(gameObject);

            // Aumente o número de objetos perdidos do jogador
            PlayerColeta.MissingObject();
        }
    }

}


