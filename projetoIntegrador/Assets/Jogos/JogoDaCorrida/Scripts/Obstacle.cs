using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float sideVelocity;
    private GameControllerJCorrida gameControllerJCorrida;
    public Transform transformDelete;


    private void Start()
    {
        gameControllerJCorrida = FindObjectOfType<GameControllerJCorrida>();
        transformDelete = GameObject.Find("Obstacles").transform;
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

        if (transformDelete != null)
        {
            if (transform.position.x <= transformDelete.transform.position.x)
                Destroy(gameObject);
        }
        else
        {
            Debug.Log("O transformDelete é nullo");
        }
    }
}
