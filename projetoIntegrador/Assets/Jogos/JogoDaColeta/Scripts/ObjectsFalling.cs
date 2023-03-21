using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsFalling : MonoBehaviour
{
    public float minFallSpeed = 1f;
    public float maxFallSpeed = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Destruir o objeto pego
            Destroy(gameObject);

            // Aumentar os erros
            PlayerColeta.MissingObject();
            Debug.Log("pontos:" + PlayerColeta.missingObjects);
        }
    }

    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
        rb.velocity = new Vector2(0f, -fallSpeed);
        Debug.Log("velocidade q ta caindo" + fallSpeed);

        if (transform.position.y < -4.5f)
        {
            // Destrua o objeto que caiu no chão
            Destroy(gameObject);
        }
    }

}


