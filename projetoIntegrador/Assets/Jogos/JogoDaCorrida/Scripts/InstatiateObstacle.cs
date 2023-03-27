using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateObstacle : MonoBehaviour
{
    public float minTimeBetweenObstacles = 1f;
    public float maxTimeBetweenObstacles = 2f;
    public float timeBetweenPairs = 0.5f;
    public GameObject prefabObstacle;

    private float nextObstacleTime = 0f;
    private int obstacleCount = 0;
    public float time;

    private void Start()
    {
        nextObstacleTime = Time.time + Random.Range(minTimeBetweenObstacles, maxTimeBetweenObstacles);
    }

    private void Update()
    {
        if (Time.time >= nextObstacleTime)
        {
            obstacleCount++;

            Instantiate(prefabObstacle, transform.position, Quaternion.identity);

            if (obstacleCount >= 2)
            {
                obstacleCount = 0;
                nextObstacleTime += timeBetweenPairs;
            }
            else
            {
                nextObstacleTime += Random.Range(minTimeBetweenObstacles, maxTimeBetweenObstacles);
            }
        }
    }
}

