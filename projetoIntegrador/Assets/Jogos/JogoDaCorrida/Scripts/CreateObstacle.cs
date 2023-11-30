using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class CreateObstacle : MonoBehaviour
{
    public List<GameObject> prefabObstacle;
    private float time;
    private GameControllerJCorrida gameControllerJCorrida;
    public float maxTime;
    public float minTime;
    private Obstacle obstacleScript;
    private Progression progressionScript;
    public float multipleSpeed;


    private void Start()
    {
        gameControllerJCorrida = FindObjectOfType<GameControllerJCorrida>();
        StartCoroutine(Spawn());
        obstacleScript = FindObjectOfType<Obstacle>();
        progressionScript = FindObjectOfType<Progression>();
    }
    IEnumerator Spawn()
    {
        while (!gameControllerJCorrida.gameOver)
        {
            int obstacleIndex = UnityEngine.Random.Range(0, prefabObstacle.Count);
            time = Random.Range(minTime, maxTime); //adicionar o minimo e maximo no inspetor da unity
            GameObject newObstacle = Instantiate(prefabObstacle[obstacleIndex], transform.position, Quaternion.identity);
            newObstacle.transform.position = new Vector2(transform.position.x, transform.position.y);
            yield return new WaitForSeconds(time); // adiciona o ytime no inspetor da unity
        }
    }
    void Update()
    {
        if (progressionScript.atingiuAMeta)
        {
            Debug.Log(progressionScript.atingiuAMeta);
            progressionScript.atingiuAMeta = false;
            obstacleScript.sideVelocity *= multipleSpeed;
            Debug.Log(obstacleScript.sideVelocity);
        }
    }
}
