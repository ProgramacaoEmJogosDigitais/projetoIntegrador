using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxJCorrida : MonoBehaviour
{

    public float objectSpeed;
    public float increaseObjectSpeed;
    private Progression progressionScript;
    private CreateObstacle createObstacleScript;
    public List<GameObject> transformsSpawn;
    public GameObject transformRemove;


    private void Start()
    {
        progressionScript = FindObjectOfType<Progression>();
        createObstacleScript = FindObjectOfType<CreateObstacle>();
    }
    private void Update()
    {
        
        if (progressionScript.atingiuAMeta)
        {
            progressionScript.atingiuAMeta = false;
            IncreaseObjectsSpeed();
            //objectSpeed = objectSpeed + increaseObjectSpeed;
        }

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
    void IncreaseObjectsSpeed() //ERRo so acelera o primeiro objeto que chega na meta primeiro
    {
        foreach (GameObject objectsInMap in progressionScript.objectsGame)
        {
            if (objectsInMap != null)
            {
                objectSpeed = objectSpeed + increaseObjectSpeed;
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


   