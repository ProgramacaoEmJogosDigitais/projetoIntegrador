using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class CreateObstacle : MonoBehaviour
{
    public List<GameObject> prefabObstacle;
    public float time;
    private GameControllerJCorrida gameControllerJCorrida;
    public float maxTime;
    public float minTime;

    private void Start()
    {
        gameControllerJCorrida = FindObjectOfType<GameControllerJCorrida>();
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (!gameControllerJCorrida.gameOver)
        {
            int obstacleIndex = UnityEngine.Random.Range(0, prefabObstacle.Count);
            time = Random.Range(minTime, maxTime); //adicionar o minimo e maximo no inspetor da unity
            yield return new WaitForSeconds(time); // adiciona o ytime no inspetor da unity
            GameObject newObstacle = Instantiate(prefabObstacle[obstacleIndex], transform.position, Quaternion.identity);
            newObstacle.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }
}
