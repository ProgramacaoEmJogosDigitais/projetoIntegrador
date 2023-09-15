using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneSpawner : MonoBehaviour
{
    public GameObject airplanePrefab;
    public List<Transform> ExitRightPositions;
    public List<Transform> ExitLeftPositions;
    public List<Transform> ArrivedRightPositions;
    public List<Transform> ArrivedLeftPositions;
    public float speed = 5.0f;
    public float spawnInterval = 5.0f;
    public bool spawn;

    private void OnEnable()
    {
        StartCoroutine(SpawnAirplanes());
    }

    private IEnumerator SpawnAirplanes()
    {
        while (spawn)
        {
            // Sorteia o lado (direita ou esquerda)
            bool isRightSide = Random.value < 0.5f;

            // Escolhe a lista de posições de saída e chegada correspondente
            List<Transform> exitPositions = isRightSide ? ExitRightPositions : ExitLeftPositions;
            List<Transform> arrivedPositions = isRightSide ? ArrivedLeftPositions : ArrivedRightPositions;

            // Sorteia uma posição de saída e uma posição de chegada
            Transform exitPoint = exitPositions[Random.Range(0, exitPositions.Count)];
            Transform arrivedPoint = arrivedPositions[Random.Range(0, arrivedPositions.Count)];

            // Instancia o avião na posição de saída
            GameObject newAirplane = Instantiate(airplanePrefab, exitPoint.position, Quaternion.identity);

            // Referência do script de movimento
            AirPlaneMovement airplaneMovement = newAirplane.GetComponent<AirPlaneMovement>();

            // Define a direção e velocidade do avião
            Vector3 direction = (arrivedPoint.position - exitPoint.position).normalized;
            airplaneMovement.Initialize(direction, speed);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

/* ---------------- DE UM LADO PARA O OUTRO ---------------------*/

//    public GameObject airplanePrefab;
//    public float minY = -4.0f;
//    public float maxY = 4.0f;

//    private void OnEnable()
//    {
//        StartCoroutine(SpawnAirplanes());
//    }

//    private IEnumerator SpawnAirplanes()
//    {
//        while (spawn)
//        {
//            // SOrteia uma posicao aleatoria de y
//            Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(minY, maxY), transform.position.z);

//            // Instancia o avião
//            GameObject newAirplane = Instantiate(airplanePrefab, spawnPosition, Quaternion.identity);

//            // Referencia do script do movimento
//            AirPlaneMovement airplaneMovement = newAirplane.GetComponent<AirPlaneMovement>();

//            // Sorteia se vai ser instanciado na direita ou na esquerda
//            Vector3 randomDirection = Random.value < 0.5f ? Vector3.right : Vector3.left;
//            float xOffset = 20.0f;

//            if (randomDirection.x > 0.5f)
//            {
//                spawnPosition.x -= xOffset; // Para esquerda
//            }
//            else
//            {
//                spawnPosition.x += xOffset; // Para direita
//            }

//            newAirplane.transform.position = spawnPosition;

//            // Avião se movimenta com a direção sorteada
//            airplaneMovement.Initialize(randomDirection, speed);

//            yield return new WaitForSeconds(spawnInterval);
//        }
//    }
//}
