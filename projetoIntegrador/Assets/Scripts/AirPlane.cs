using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlane : MonoBehaviour
{
    public float time;
    public GameObject[] prefabClients;
    public bool stop;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (stop)
        {
            time = Random.Range(1, 10);
            yield return new WaitForSeconds(time);
            Instantiate(prefabClients[Random.Range(0, prefabClients.Length)], transform.position, Quaternion.identity);
        }
    }
}
