using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private float sideVelocity;
    private GameControllerJCorrida gameControllerJCorrida;
    private PauseJCorrida pauseJCorridaScript;
    private BookSystem bookSystemScript;
    public bool collectedBook;


    private void Start()
    {
        gameControllerJCorrida = FindObjectOfType<GameControllerJCorrida>();
        bookSystemScript = FindObjectOfType<BookSystem>();
        pauseJCorridaScript = FindObjectOfType<PauseJCorrida>();
        collectedBook = false;
    }

    public void SetBookSpeed(float speed)
    {
        sideVelocity = speed;
    }

    void Update() //faz o obstaculo se mover para a esquerda e destroy
    {
        if (!gameControllerJCorrida.gameOver && pauseJCorridaScript.gamePaused == false)
        {
            transform.Translate(Vector3.left * sideVelocity * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            collectedBook = true;
            bookSystemScript.nBooks++;
            Debug.Log("numeros de livros pegados: " +bookSystemScript.nBooks);
            Destroy(gameObject);

        }

    }
}
