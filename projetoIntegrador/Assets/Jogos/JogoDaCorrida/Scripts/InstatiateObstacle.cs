using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateObstacle : MonoBehaviour
{
    public float time;
    public GameObject prefabObstacle;
    public bool stop;

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (stop)
        {
            time = Random.Range(0, 3);
            yield return new WaitForSeconds(time);
            Instantiate(prefabObstacle, transform.position, Quaternion.identity);
        }
    }
}
