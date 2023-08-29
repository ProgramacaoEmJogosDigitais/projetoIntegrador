using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirPlaneMovement : MonoBehaviour
{
    private Vector3 direction;
    private float speed;
    public void Initialize(Vector3 dir, float spd)
    {
        direction = dir;
        speed = spd;
    }

    private void Update()
    {
        if(direction.x > 0.5f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        transform.Translate(direction * speed * Time.deltaTime);

        // Verifica se o avião saiu dos limites e destrói
        if ((direction.x > 0 && transform.position.x > 20) || (direction.x < 0 && transform.position.x < -20))
        {
            Destroy(gameObject);
        }
    }
}


