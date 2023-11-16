using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public GameObject prefabObstacle;
    public float time;
    private GameControllerJCorrida gameControllerJCorrida;

    private void Start()
    {
        gameControllerJCorrida = FindObjectOfType<GameControllerJCorrida>();
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (!gameControllerJCorrida.gameOver)
        {
            time = Random.Range(3, 5f);
            yield return new WaitForSeconds(time);

            GameObject newObstacle = Instantiate(prefabObstacle, transform.position, Quaternion.identity);
            newObstacle.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }
}
