using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public List<GameObject> prefabObstacle;
    private GameControllerJCorrida gameControllerJCorrida;
    public float maxTime;
    public float minTime;
    private Progression progressionScript;
    public float multipleSpeed;
    private float speedChangeInterval = 5.0f;
    private float speedChangeTimer = 0.0f;
    private float currentSpeed = 8.0f;
    private List<Obstacle> spawnedObstacles = new List<Obstacle>(); // Lista de obstáculos instanciados

    private void Start()
    {
        gameControllerJCorrida = FindObjectOfType<GameControllerJCorrida>();
        StartCoroutine(Spawn());
        progressionScript = FindObjectOfType<Progression>();
    }

    IEnumerator Spawn()
    {
        while (!gameControllerJCorrida.gameOver)
        {
            int obstacleIndex = Random.Range(0, prefabObstacle.Count);

            GameObject newObstacle = Instantiate(prefabObstacle[obstacleIndex], transform.position, Quaternion.identity);
            Obstacle obstacleScript = newObstacle.GetComponent<Obstacle>();
            obstacleScript.SetObstacleSpeed(currentSpeed);
            spawnedObstacles.Add(obstacleScript);

            newObstacle.transform.position = new Vector2(transform.position.x, transform.position.y);

            float time = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(time);
        }
    }

    void Update()
    {
        speedChangeTimer += Time.deltaTime;

        if (speedChangeTimer >= speedChangeInterval)//TODO: Fazer logica de quando muda velocidade.
        {
            IncreaseObstacleSpeed();
            speedChangeTimer = 0.0f;
        }
    }

    void IncreaseObstacleSpeed()
    {
        currentSpeed += 20.0f;//TODO Fazer logica da velocidade;

        foreach (Obstacle obstacle in spawnedObstacles)
        {
            if (obstacle != null)
            {
                obstacle.SetObstacleSpeed(currentSpeed);
            }
        }
    }
}
