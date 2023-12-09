using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public List<GameObject> prefabObstacle;
    private GameControllerJCorrida gameControllerJCorrida;
    public float maxTime;
    public float minTime;
    public float increaseMaxTime;
    private Progression progressionScript;
    public float currentSpeedInfor;
    public bool progressCreateOScript;
    private List<Obstacle> spawnedObstacles { get; set; } = new List<Obstacle>(); // Lista de obstáculos instanciados

    private void Start()
    {
        gameControllerJCorrida = FindObjectOfType<GameControllerJCorrida>();
        StartCoroutine(Spawn());
        progressionScript = FindObjectOfType<Progression>();
        progressCreateOScript = false;
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
        if (progressionScript.atingiuAMeta)//TODO: Fazer logica de quando muda velocidade.
        {
            Debug.Log("ENTROUUU");
            //progressionScript.atingiuAMeta = false;
            progressCreateOScript = true;
            currentSpeedInfor++;
            IncreaseObstacleSpeed();
            maxTime = maxTime + increaseMaxTime;
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