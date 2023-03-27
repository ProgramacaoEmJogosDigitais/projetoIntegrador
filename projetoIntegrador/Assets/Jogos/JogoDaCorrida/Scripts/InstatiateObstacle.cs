using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstatiateObstacle : MonoBehaviour
{
    public float minTimeBetweenObstacles = 1.5f;
    public float maxTimeBetweenObstacles = 2.5f;
    public GameObject prefabObstacle;
    public bool stopInstatiateObstacle = false;
    private void Start()
    {
        stopInstatiateObstacle = false;
    }
    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (!stopInstatiateObstacle)
        {
            float time = Random.Range(minTimeBetweenObstacles, maxTimeBetweenObstacles);
            yield return new WaitForSeconds(time);
            Instantiate(prefabObstacle, transform.position, Quaternion.identity);
        }
    }
}

