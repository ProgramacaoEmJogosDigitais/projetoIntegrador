using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject Objects;

    void Start()
    {
        StartCoroutine(GenerateObject());
    }

    IEnumerator GenerateObject()
    {
        while (true)
        {
            float x = Random.Range(-8f, 8f);
            float y = 7f;
            Vector2 initialPosition = new Vector2(x, y);
            Instantiate(Objects, initialPosition, Quaternion.identity);
            yield return new WaitForSeconds(2.5f);
        }
    }
 }