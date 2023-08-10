using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentAirPlane : MonoBehaviour
{
    float velocity;

    void Start()
    {
        velocity = Random.Range(1, 4);
    }

    void Update()
    {
        transform.Translate(velocity * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(this.gameObject);
        }




    }
}
