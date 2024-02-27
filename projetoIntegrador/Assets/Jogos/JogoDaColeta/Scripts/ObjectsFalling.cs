using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsFalling : MonoBehaviour
{
    public float fallSpeed = 1f;

    private AudioSource audioSource;

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Destruir o objeto pego
    //        Destroy(gameObject);

    //        Aumentar os erros
    //        PlayerColeta.MissingObject();
    //    }
    //}

    void Awake()
    {
        // Obtém o componente AudioSource do próprio objeto
        audioSource = GetComponent<AudioSource>();

        // Verifica se o AudioSource foi encontrado
        if (audioSource != null)
        {
            // Inicia a reprodução, se necessário
            audioSource.Play();
        }
    }

    void Update()
    {
        audioSource.volume = VolumeControl.volumeEffect;


        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, -fallSpeed);

        if (transform.position.y < -4.5f)
        {
            // Destruir o objeto que caiu no chão
            Destroy(gameObject);

            // Aumentar o número de objetos perdidos do jogador
            PlayerColeta.missingObjects--;
        }
    }

}


