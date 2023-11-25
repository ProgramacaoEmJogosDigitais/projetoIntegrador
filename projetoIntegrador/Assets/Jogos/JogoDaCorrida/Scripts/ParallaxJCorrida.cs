using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxJCorrida : MonoBehaviour
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
        transform.Translate(direction * speed * Time.deltaTime);

        // Verifica se o objeto saiu dos limites e destrói
        if (direction.x < 0 && transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}
