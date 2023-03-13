using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject objeto;
    public float velocidadeDeQueda = 5f;
    public float taxaDeGeracao = 1f;

    void Start()
    {
        InvokeRepeating("GerarObjeto", 0f, taxaDeGeracao);
    }

    void GerarObjeto()
    {
        float x = Random.Range(-8f, 8f);
        float y = 7f;
        Vector2 posicaoInicial = new Vector2(x, y);
        Instantiate(objeto, posicaoInicial, Quaternion.identity);
    }
}
