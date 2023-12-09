using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxJCorrida : MonoBehaviour
{
    private const int count = 10;
    public float objectSpeed;
    public float increaseObjectSpeed;
    private Progression progressionScript;
    public List<GameObject> transformsSpawn;
    public GameObject transformRemove;
    public bool progressParallaxJScript;


    private void Start()
    {
        progressionScript = FindObjectOfType<Progression>();
        progressParallaxJScript = false;
    }
    private void Update()
    {
        
        if (progressionScript.atingiuAMeta)
        {
            //progressionScript.atingiuAMeta = false;
            progressParallaxJScript = true;
            ParallaxJCorrida[] objectsGame = FindObjectsOfType<ParallaxJCorrida>(); // procura todos objetos com esse script
            foreach (ParallaxJCorrida obj in objectsGame)
            {
                obj.IncreaseObjectsSpeed();
            }
        }

        transform.Translate(Vector3.left * objectSpeed * Time.deltaTime);

        // Verifica se o objeto saiu dos limites realinha a posicao
        if (transform.position.x <= transformRemove.transform.position.x) 
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
    void IncreaseObjectsSpeed()// Aumenta a velocidade
    {
        objectSpeed = objectSpeed + increaseObjectSpeed;
    }
}


   