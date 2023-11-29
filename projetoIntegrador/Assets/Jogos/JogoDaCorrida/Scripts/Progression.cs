using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Progression : MonoBehaviour
{
    private MovimentPlayer movimentPlayerScript;
    public float inclementoDePontos;
    public float metaParaInclemento;
    public float incrementoSpeeadPoints;
    public bool ÈMaior;
    void Start()
    {
        movimentPlayerScript = FindObjectOfType<MovimentPlayer>();
        ÈMaior = false;
    }
    void Update()
    {
        if (movimentPlayerScript.distance >= metaParaInclemento)
        {
            ÈMaior=true;
            AcelerarCorrida();
        }
    }

    void AcelerarCorrida()
    {
        if (ÈMaior)
        {
            metaParaInclemento = +inclementoDePontos;
            movimentPlayerScript.speedPoints = movimentPlayerScript.speedPoints * incrementoSpeeadPoints;
            ÈMaior = false;
        }
    }
}