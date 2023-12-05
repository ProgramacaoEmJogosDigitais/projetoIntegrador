using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxJCorrida : MonoBehaviour
{

    public float objectSpeed;
    private Progression progressionScript;
    private CreateParallaxJCorrida createParallaxJCorridaScript;
    public List<GameObject> transformsSpawn;
    public GameObject transformRemove;


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

        // Verifica se o objeto saiu dos limites realinha a posicao
        if (transform.position.x <= transformRemove.transform.position.x) //x >= -1600f;
        {
            int indexLocalSpawn = UnityEngine.Random.Range(0, transformsSpawn.Count); // Sorteia o local
            //GameObject objectParallax = Instantiate(gameObject, transform.position, Quaternion.identity); //instancia
            gameObject.transform.position = new Vector2(transformsSpawn[indexLocalSpawn].transform.position.x, transformsSpawn[indexLocalSpawn].transform.position.y); //coloca na posicao do local sorteado;           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnNewObject"))
        {
            //createParallaxJCorridaScript.spawn = true;
            Debug.Log($"Tocouu,{collision.name}");
            Debug.Log(createParallaxJCorridaScript.spawn);
        }
    }
   
}


   