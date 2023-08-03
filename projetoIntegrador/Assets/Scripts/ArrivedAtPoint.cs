using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivedAtPoint : MonoBehaviour
{
    private LinkTarget linkTarget;
    private TargetMap targetMap;
    
    void Start()
    {
        linkTarget = GetComponent<LinkTarget>();
        targetMap = GetComponent<TargetMap>();
    }

    void Update ()
    {
        if (linkTarget.atPoint)//se o carro esta no ponto turistico, aumenta a escala dele
        {
            Debug.Log("entrouuuu");
            this.transform.GetChild(0).localScale = new Vector3(transform.localScale.x + 0.00001f, transform.localScale.y + 0.00001f, transform.localScale.z + 0.00001f);
        }
        else // se nao tiver no ponto fica com sua escala "normal"
        {
            this.transform.GetChild(0).localScale = new Vector3(0.40006f, 0.40006f, 0.40006f);
        }
    }
}
