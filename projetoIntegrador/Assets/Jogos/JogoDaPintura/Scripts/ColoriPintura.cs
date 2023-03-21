using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ColoriPintura : MonoBehaviour
{
  
    // Start is called before the first frame update
    public GameObject[] pinturasCompetitivo;
    public int numeroPinturaCompetitivo,tempoFigura, comperePictures;
    public Material semCorPinturaCompetitivo;
    public TextMeshProUGUI txtContador;
    public bool stopContagePicture;
    public Material[] materiaisPinturaCompetitivo, materiaisFilhosPinturaCompetitivo;






    void Start()
    {
        comperePictures = 0;
        ApagaPinturaClassico();
        DataPintura.vetorComparacaoPintura=new int[materiaisFilhosPinturaCompetitivo.Length];
        DataPintura.vectorCollorSelect = new int[materiaisFilhosPinturaCompetitivo.Length];
        numeroPinturaCompetitivo = Random.Range(0, pinturasCompetitivo.Length);
        pinturasCompetitivo[numeroPinturaCompetitivo].SetActive(true);
        GeradorDeCoresPintura();
        PintaFigura();
       

    }

    // Update is called once per frame
    void Update()
    {
        if (DataPintura.contageFigureResete == 10)
        {
            ResetaPinturaCompetitivo();


        }
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
    public void CompareFiguresCollor()
    {
        for (int i = 0; i < materiaisFilhosPinturaCompetitivo.Length; i++)
        {
            if (DataPintura.vectorCollorSelect[i] != DataPintura.vetorComparacaoPintura[i])
            {
                comperePictures ++;
            }
           
        }
        if (comperePictures == 0)
        {
            Debug.Log("ganhou");

            SceneManager.LoadScene("MenuJogoDaPintura");
        }
        else
        {
            Debug.Log("perdeu");
            SceneManager.LoadScene("MenuJogoDaPintura");


        }

    }

   
   
}


