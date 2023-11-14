using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int sideVelocity;

    //private Bird scriptBird;
    private void Start()
    {
        //scriptBird = FindObjectOfType<Bird>();
    }
    void Update()
    {
        //if (!scriptBird.gameOver)
        //{
            transform.Translate(-sideVelocity * Time.deltaTime, 0, 0);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DestroyObstacle"))
        {
            Destroy(gameObject);
        }
    }
}
