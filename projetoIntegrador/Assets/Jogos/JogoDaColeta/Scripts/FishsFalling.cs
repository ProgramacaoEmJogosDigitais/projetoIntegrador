using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishsFalling : MonoBehaviour
{
    public float fallSpeed = 1f;
    public static int pointsFish = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Destruir o objeto pego
            Destroy(gameObject);

            // Aumentar a pontua��o do jogador
            pointsFish++;
        }
    }
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, -fallSpeed);

        if (transform.position.y < -4.5f)
        {
            // Destruir o objeto que caiu
            Destroy(gameObject);

            // Aumentar o n�mero de objetos perdidos do jogador
            PlayerColeta.MissingObject();
        }
    }

}


