using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject Objects;
    public float fallingInterval = 5f;

    void Start()
    {
        InvokeRepeating("GenerateObject", 0f, fallingInterval);
    }

    void GenerateObject()
    {
        float x = Random.Range(-8f, 8f);
        float y = 7f;
        Vector2 initialPosition = new Vector2(x, y);
        Instantiate(Objects, initialPosition, Quaternion.identity);
    }
 }