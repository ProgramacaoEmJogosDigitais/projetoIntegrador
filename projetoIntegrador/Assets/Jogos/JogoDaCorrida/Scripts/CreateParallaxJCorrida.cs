using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateParallaxJCorrida : MonoBehaviour
{
    public List<GameObject> objectPrefab;
    private float spawnInterval;
    public bool spawn ;
    public float maxTime;
    public float minTime;
    public float minY;
    public float maxY;

    private void Awake()
    {
        //spawn = false;

    }
    private void Start()
    {

        //StartCoroutine(SpawnObjectsParallax());
    }

    private void Update()
    {
        if (spawn)
        {
            Spaw();
            Debug.Log("QQQQQ: " + spawn);
        }
    }
    
    private void Spaw()
    {
        spawn = false;
        int obstacleIndex = UnityEngine.Random.Range(0, objectPrefab.Count);
        // Instancia o objeto
        float variateYCloud = UnityEngine.Random.Range(minY, maxY);
        GameObject objectParallax = Instantiate(objectPrefab[obstacleIndex], transform.position, Quaternion.identity);
        objectParallax.transform.position = new Vector2(transform.position.x, variateYCloud);

        //spawnInterval = Random.Range(minTime, maxTime); //adicionar o minimo e maximo no inspetor da unity

    }
    /*
    private IEnumerator SpawnObjectsParallax()
    {
        while (spawn)
        {
            int obstacleIndex = UnityEngine.Random.Range(0, objectPrefab.Count);
            // Instancia o objeto
            float variateYCloud = UnityEngine.Random.Range(minY, maxY);
            GameObject objectParallax = Instantiate(objectPrefab[obstacleIndex], transform.position, Quaternion.identity);
            objectParallax.transform.position = new Vector2(transform.position.x, variateYCloud);

            spawnInterval = Random.Range(minTime, maxTime); //adicionar o minimo e maximo no inspetor da unity

            yield return new WaitForSeconds(spawnInterval);
        }
    }*/

    
}
