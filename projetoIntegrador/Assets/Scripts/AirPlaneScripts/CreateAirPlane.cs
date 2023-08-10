using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAirPlane : MonoBehaviour
{
    public float time;
    public GameObject prefabAirPlane;
    public bool stop;

    private float yValue;
    private GameObject objectIntantiated;

    void Start()
    {

    }
    private void OnEnable()
    {
        StartCoroutine(SpawnAirPlane());
    }
    IEnumerator SpawnAirPlane()
    {
        while (stop)
        {
            time = Random.Range(1, 2);
            yValue = Random.Range(-1.72f, -5.64f);
            yield return new WaitForSeconds(time);
            objectIntantiated = Instantiate(prefabAirPlane, transform.position, Quaternion.identity);
            objectIntantiated.transform.position = new Vector3(transform.position.x, yValue, 50f);
        }
    }
}
