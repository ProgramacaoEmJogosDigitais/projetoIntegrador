using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorDeCor : MonoBehaviour
{
    public Material[] coresPossiveis; 
    public Material corDoObjeto;
    public int vectorCollorIndice;
    // Start is called before the first frame update
    void OnMouseOver()
    {

        this.transform.localScale = new Vector3(2.1f, 2.1f, 2.0f);



        if (Input.GetMouseButtonUp(0))
        {

            corDoObjeto.color = coresPossiveis[DataPintura.numeroCorSelecionada].color;
            DataPintura.vectorCollorSelect[vectorCollorIndice] = DataPintura.numeroCorSelecionada;


        }
    }
    void OnMouseExit()
    {
        this.transform.localScale = new Vector3(2, 2, 2);

    }
}
