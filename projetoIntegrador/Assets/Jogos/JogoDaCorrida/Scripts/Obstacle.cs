using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float sideVelocity;
    private GameControllerJCorrida gameControllerJCorrida;
    private Progression progressionScript;

    //public float multipleSpeed;
    private void Start()
    {
        gameControllerJCorrida = FindObjectOfType<GameControllerJCorrida>();
        progressionScript = FindObjectOfType<Progression>();
    }
    void Update()
    {
        /*if (progressionScript.atingiuAMeta)
        {
            Debug.Log(progressionScript.atingiuAMeta);
            progressionScript.atingiuAMeta = false;
            sideVelocity += multipleSpeed;
            Debug.Log(sideVelocity);
        }*/

        if (!gameControllerJCorrida.gameOver)
        {
            transform.Translate(Vector3.left * sideVelocity * Time.deltaTime);
            //transform.Translate(-sideVelocity * Time.deltaTime, 0, 0);
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
