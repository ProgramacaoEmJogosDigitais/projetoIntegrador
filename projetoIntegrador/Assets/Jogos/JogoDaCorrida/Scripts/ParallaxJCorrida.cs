using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxJCorrida : MonoBehaviour
{
    
    public float objectSpeed; 
    private void Update()
    {
        transform.Translate(Vector3.left * objectSpeed * Time.deltaTime);
        // Verifica se o objeto saiu dos limites e destrói
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }

}


    /*
    public float parallaxSpeed; // Velocidade do parallax
    public float destroyXPosition = -10f; // Posição em X para destruir o objeto
    public GameObject nextObjectPrefab; // Prefab do próximo objeto a ser instanciado 
    public float instantiateXPosition = 10f; // Posição em X para instanciar o próximo objeto 
    public float spawnInterval = 2f;
    public bool spawn;

    private void Start()
    {
        spawn = true;
    }
    void Update()
    {
        // Move o objeto para a esquerda com base na velocidade de parallax
        transform.Translate(Vector3.left * parallaxSpeed * Time.deltaTime);


        // Verifica se o objeto atingiu a posição de destruição
        if (transform.position.x <= destroyXPosition)
        {
            Destroy(gameObject);
        }


        // Verifica se o objeto atingiu a posição de instanciação
        if (transform.position.x <= instantiateXPosition)
        {
            StartCoroutine(InstantiateNextObject());
        }
    }

    private IEnumerator InstantiateNextObject()
    {
        while (spawn)
        {
            if (nextObjectPrefab != null)
            {
                GameObject nextObject = Instantiate(nextObjectPrefab, new Vector3(instantiateXPosition, transform.position.y, transform.position.z), Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    //void InstantiateNextObject()
    //{
    //    // Instancia o próximo objeto na posição especificada
    //    if (nextObjectPrefab != null)
    //    {
    //        GameObject nextObject = Instantiate(nextObjectPrefab, new Vector3(instantiateXPosition, transform.position.y, transform.position.z), Quaternion.identity);
    //    }
    //}
}
    */