using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxJCorrida : MonoBehaviour
{

    public float objectSpeed;
    private Progression progressionScript;
    private CreateParallaxJCorrida createParallaxJCorridaScript;

    private void Start()
    {
        progressionScript = FindObjectOfType<Progression>();
        createParallaxJCorridaScript = FindObjectOfType<CreateParallaxJCorrida>();
    }
    private void Update()
    {
        /*
        if (progressionScript.atingiuAMeta)
        {
            progressionScript.atingiuAMeta = false;
            objectSpeed *= multipleSpeed;

        }*/

        transform.Translate(Vector3.left * objectSpeed * Time.deltaTime);
        // Verifica se o objeto saiu dos limites e destrói
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnNewObject"))
        {
            Debug.Log("EEEEEEEEEEEEEEEEEEEE");
            createParallaxJCorridaScript.spawn = true;
        }
    }
   
}


   