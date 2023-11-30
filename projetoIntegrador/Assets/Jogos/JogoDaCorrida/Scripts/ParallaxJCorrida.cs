using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxJCorrida : MonoBehaviour
{
    
    public float objectSpeed;
    private Progression progressionScript;

    private void Start()
    {
        progressionScript = FindObjectOfType<Progression>();
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

}


   