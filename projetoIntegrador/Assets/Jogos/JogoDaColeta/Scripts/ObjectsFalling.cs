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
        // Obt�m o componente AudioSource do pr�prio objeto
        audioSource = GetComponent<AudioSource>();

        // Verifica se o AudioSource foi encontrado
        if (audioSource != null)
        {
            // Inicia a reprodu��o, se necess�rio
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
            // Destruir o objeto que caiu no ch�o
            Destroy(gameObject);

            // Aumentar o n�mero de objetos perdidos do jogador
            PlayerColeta.missingObjects--;
        }
    }

}


