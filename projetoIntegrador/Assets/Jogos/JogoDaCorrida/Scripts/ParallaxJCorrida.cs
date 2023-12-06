using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxJCorrida : MonoBehaviour
{

    public float objectSpeed;
    private Progression progressionScript;
    public List<GameObject> transformsSpawn;
    public GameObject transformRemove;


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

        // Verifica se o objeto saiu dos limites realinha a posicao
        if (transform.position.x <= transformRemove.transform.position.x) //x >= -1600f;
        {
            int indexLocalSpawn = UnityEngine.Random.Range(0, transformsSpawn.Count); // Sorteia o local
            int indexFlip = UnityEngine.Random.Range(0, 1); //Sorteia se vai fliparou não 
            gameObject.transform.position = new Vector2(transformsSpawn[indexLocalSpawn].transform.position.x, transformsSpawn[indexLocalSpawn].transform.position.y); //coloca na posicao do local sorteado;
            if(indexFlip == 0)//0 == flip
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }                                                                                                                                                          

        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnNewObject"))
        {
            //createParallaxJCorridaScript.spawn = true;
            Debug.Log($"Tocouu,{collision.name}");
            Debug.Log(createParallaxJCorridaScript.spawn);
        }
    }*/
   
}


   