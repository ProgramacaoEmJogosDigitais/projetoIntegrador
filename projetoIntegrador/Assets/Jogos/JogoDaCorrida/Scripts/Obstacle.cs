using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float velocity;

    void Update()
    {
        transform.Translate(-velocity * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DestroyObstacle"))
        {
            Destroy(gameObject);
        }
    }
}


