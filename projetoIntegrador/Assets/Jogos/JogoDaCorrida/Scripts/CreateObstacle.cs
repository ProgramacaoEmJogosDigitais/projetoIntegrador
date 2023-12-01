using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public List<GameObject> prefabObstacle;
    private GameControllerJCorrida gameControllerJCorrida;
    private MovimentPlayer movimentPlayerScript;
    private Obstacle obstacleScript;
    public float maxTime;
    public float minTime;
    private Progression progressionScript;
    public float multipleSpeed;
    private float speedChangeInterval = 5.0f;
    private float speedChangeTimer = 0.0f;
    public float currentSpeedInfor;
    private List<Obstacle> spawnedObstacles = new List<Obstacle>(); // Lista de obstáculos instanciados

    private void Start()
    {
        gameControllerJCorrida = FindObjectOfType<GameControllerJCorrida>();
        StartCoroutine(Spawn());
        progressionScript = FindObjectOfType<Progression>();
        movimentPlayerScript = FindObjectOfType<MovimentPlayer>();
        obstacleScript = FindObjectOfType<Obstacle>();
    }

    IEnumerator Spawn()
    {
        while (!gameControllerJCorrida.gameOver)
        {
            int obstacleIndex = Random.Range(0, prefabObstacle.Count);

            GameObject newObstacle = Instantiate(prefabObstacle[obstacleIndex], transform.position, Quaternion.identity);
            Obstacle obstacleScript = newObstacle.GetComponent<Obstacle>();
            obstacleScript.SetObstacleSpeed(currentSpeedInfor);
            spawnedObstacles.Add(obstacleScript);
            newObstacle.transform.position = new Vector2(transform.position.x, transform.position.y);
            float time = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(time);
        }
    }

    void Update()
    {
        if (movimentPlayerScript.distance>=progressionScript.meta)//TODO: Fazer logica de quando muda velocidade.
        {
            progressionScript.meta += 10;
            IncreaseObstacleSpeed();
            currentSpeedInfor++;
        }
    }

    void IncreaseObstacleSpeed()
    {
        foreach (Obstacle obstacle in spawnedObstacles)
        {
            if (obstacle != null)
            {
                obstacle.SetObstacleSpeed(currentSpeedInfor);
            }
        }
    }
}
