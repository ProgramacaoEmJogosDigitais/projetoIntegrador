using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateParallaxJCorrida : MonoBehaviour
{
    public List<GameObject> objectPrefab;
    private float spawnInterval;
    public bool spawn;
    public float maxTime;
    public float minTime;
    public float minY;
    public float maxY;

    private void Start()
    {
        StartCoroutine(SpawnObjectsParallax());
        spawn = true;
    }

    private IEnumerator SpawnObjectsParallax()
    {
        while (spawn)
        {
            int obstacleIndex = UnityEngine.Random.Range(0, objectPrefab.Count);
            //entre o 0 e o 5
            // Instancia o objeto
            float variateYCloud = UnityEngine.Random.Range(minY, maxY);
            GameObject objectParallax = Instantiate(objectPrefab[obstacleIndex], transform.position, Quaternion.identity);
            objectParallax.transform.position = new Vector2(transform.position.x, variateYCloud);

            spawnInterval = Random.Range(minTime, maxTime); //adicionar o minimo e maximo no inspetor da unity

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
