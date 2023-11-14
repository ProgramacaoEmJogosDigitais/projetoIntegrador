using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public GameObject prefabObstacle;
    public float time;

    private void OnEnable()
    {
        //scriptBird = FindObjectOfType<Bird>();
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        //while (!scriptBird.gameOver)
        //{
        time = Random.Range(1, 2.5f);
        yield return new WaitForSeconds(time);

        GameObject newObstacle = Instantiate(prefabObstacle, transform.position, Quaternion.identity);
        newObstacle.transform.position = new Vector2(transform.position.x, transform.position.y);
        // }
    }
}
