using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Progression : MonoBehaviour
{
    private MovimentPlayer movimentPlayerScript;
    public float inclementoDePontos;
    //public float aumentaOProgresso;
    public float metaParaInclemento;
    public float incrementoSpeeadPoints;
    public bool �Maior;
    void Start()
    {
        movimentPlayerScript = FindObjectOfType<MovimentPlayer>();
        �Maior = false;
    }
    void Update()
    {
        if (movimentPlayerScript.distance >= metaParaInclemento)
        {
            �Maior=true;
            AcelerarCorrida();
        }
    }

    void AcelerarCorrida()
    {
        if (�Maior)
        {
            metaParaInclemento = +inclementoDePontos;
            movimentPlayerScript.speedPoints = movimentPlayerScript.speedPoints * incrementoSpeeadPoints;
        Debug.Log("metaParaInclemento:" + metaParaInclemento);
        Debug.Log("inclementoDePontos:" + inclementoDePontos);
        Debug.Log("movimentPlayerScript.speedPoints:" + movimentPlayerScript.speedPoints);
            �Maior = false;
        }
    }
}