using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float sideVelocity;
    private GameControllerJCorrida gameControllerJCorrida;

    private void Start()
    {
        gameControllerJCorrida = FindObjectOfType<GameControllerJCorrida>();
    }

    public void SetObstacleSpeed(float speed)
    {
        sideVelocity = speed;
    }

    void Update()
    {
        if (!gameControllerJCorrida.gameOver)
        {
            transform.Translate(Vector3.left * sideVelocity * Time.deltaTime);
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
