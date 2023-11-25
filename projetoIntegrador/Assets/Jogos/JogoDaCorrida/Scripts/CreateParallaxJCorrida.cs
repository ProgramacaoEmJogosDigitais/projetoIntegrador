using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateParallaxJCorrida : MonoBehaviour
{
    //public float minY = -4.0f;
    //public float maxY = 4.0f;
    public GameObject objectPrefab;
    //public List<Transform> ExitRightPositions;
    //public List<Transform> ExitLeftPositions;
    //public List<Transform> ArrivedRightPositions;
    //public List<Transform> ArrivedLeftPositions;
    public float speedObject;
    public float spawnInterval;
    public bool spawn;
    //public Transform localSpawn;

    private void OnEnable()
    {
        StartCoroutine(SpawnObjectsParallax());
    }

    private IEnumerator SpawnObjectsParallax()
    {
        while (spawn)
        {
            // SOrteia uma posicao aleatoria de y
            //Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(minY, maxY), transform.position.z);

            // Instancia o avião
            
            Vector3 localSpawn = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject newObjectParallax = Instantiate(objectPrefab, localSpawn, Quaternion.identity);
            
            // Referencia do script do movimento
            AirPlaneMovement airplaneMovement = newObjectParallax.GetComponent<AirPlaneMovement>();

            // Sorteia se vai ser instanciado na direita ou na esquerda
            //Vector3 randomDirection = Random.value < 0.5f ? Vector3.right : Vector3.left;
            float xOffset = 20.0f;

            //if (randomDirection.x > 0.5f)
            //{
                localSpawn.x -= xOffset; // Para esquerda
            //}
            //else
            //{
                //spawnPosition.x += xOffset; // Para direita
            //}

            newObjectParallax.transform.position = localSpawn;

            // Avião se movimenta com a direção sorteada
            airplaneMovement.Initialize(localSpawn, speedObject);
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
