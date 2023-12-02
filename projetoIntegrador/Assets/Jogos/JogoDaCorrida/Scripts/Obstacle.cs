using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float sideVelocity;
    private GameControllerJCorrida gameControllerJCorrida;
    private void Start()
    {
        gameControllerJCorrida = FindObjectOfType<GameControllerJCorrida>();
    }
    void Update()
    {
        if (!gameControllerJCorrida.gameOver)
        {
            transform.Translate(-sideVelocity * Time.deltaTime, 0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DestroyObstacle"))
        {
            Destroy(gameObject);
        }
    }
}
