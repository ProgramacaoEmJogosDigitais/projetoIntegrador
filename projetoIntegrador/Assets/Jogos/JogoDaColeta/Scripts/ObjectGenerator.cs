using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject Objects;
    public float fallingSpeed = 5f;
    public float taxaDeGeracao = 1f;

    void Start()
    {
        InvokeRepeating("GenerateObject", 0f, fallingSpeed);
    }

    void GenerateObject()
    {
        float x = Random.Range(-8f, 8f);
        float y = 7f;
        Vector2 initialPosition = new Vector2(x, y);
        Instantiate(Objects, initialPosition, Quaternion.identity);
    }
 }