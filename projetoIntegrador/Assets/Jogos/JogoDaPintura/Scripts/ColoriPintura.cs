using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColoriPintura : MonoBehaviour
{
  
    // Start is called before the first frame update
    public GameObject[] pinturasCompetitivo;
    public int numeroPinturaCompetitivo,tempoFigura;
    public Material semCorPinturaCompetitivo;
    public TextMeshProUGUI txtContador;
    public bool stopContagePicture;

    public Material[] materiaisPinturaCompetitivo, materiaisFilhosPinturaCompetitivo;
    void Start()
    {
        ApagaPinturaClassico();
        DataPintura.vetorComparacaoPintura=new int[materiaisFilhosPinturaCompetitivo.Length];
        numeroPinturaCompetitivo = Random.Range(0, pinturasCompetitivo.Length);
        pinturasCompetitivo[numeroPinturaCompetitivo].SetActive(true);
        GeradorDeCoresPintura();
        PintaFigura();
        ContadorFigura();
        ResetaPinturaCompetitivo();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GeradorDeCoresPintura()
    {
        for (int i = 0; i < (materiaisFilhosPinturaCompetitivo.Length); i++)
        {
            DataPintura.vetorComparacaoPintura[i] = Random.Range(0, materiaisFilhosPinturaCompetitivo.Length);
        }
      

    }
    void PintaFigura()
    {
        for (int i = 0; i <materiaisFilhosPinturaCompetitivo.Length ; i++)
        {
            materiaisFilhosPinturaCompetitivo[i].color = materiaisPinturaCompetitivo[DataPintura.vetorComparacaoPintura[i]].color;


        }
    }
    void ApagaPinturaClassico()
    {
 
        for (int i = 0; i < pinturasCompetitivo.Length; i++)
        {
            pinturasCompetitivo[i].SetActive(false);
        }
    }
    void ResetaPinturaCompetitivo()
    {
       


        for (int i = 0; i < materiaisFilhosPinturaCompetitivo.Length; i++)
        {
            materiaisFilhosPinturaCompetitivo[i].color = semCorPinturaCompetitivo.color;

        }


    }
   
   
}


