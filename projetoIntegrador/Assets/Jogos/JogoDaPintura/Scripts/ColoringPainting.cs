using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColoringPainting : MonoBehaviour
{
  
    // Start is called before the first frame update
    public GameObject[] competitivePicture;
    public int competitivePictureNumber, comparePictures;
    public Material noCollorPictureCompetitive;
    public float percetageVictory;
    public Material[] materialPictureCompetitive, matirialFigureCompetitive;

    void Start()
    {
        ErasePictureCompetitive();
        DataPintura.startGamePicture = false;
        DataPintura.vectorComparisonPainting = new int[matirialFigureCompetitive.Length];
        DataPintura.vectorCollorSelect = new int[matirialFigureCompetitive.Length];
        competitivePictureNumber = Random.Range(0, competitivePicture.Length);
        competitivePicture[competitivePictureNumber].SetActive(true);
        ResetPictureCompetitive();

    }
    public void StartGamePicture()
    {
        DataPintura.startGamePicture = true;
        comparePictures = 0;
        GeratorDeCollorPicture();
        PaintFigure();
    }

    // Update is called once per frame
    void Update()
    {
        if (DataPintura.contageFigureResete == DataPintura.numberTimeFigureData)
        {
            ResetPictureCompetitive();
            DataPintura.contageFigureResete++;
        }
    }
    void GeratorDeCollorPicture()
    {
        for (int i = 0; i < (matirialFigureCompetitive.Length); i++)
        {
            DataPintura.vectorComparisonPainting[i] = Random.Range(0, matirialFigureCompetitive.Length);
        }
    }
    void PaintFigure()
    {
        for (int i = 0; i <matirialFigureCompetitive.Length ; i++)
        {
            matirialFigureCompetitive[i].color = materialPictureCompetitive[DataPintura.vectorComparisonPainting[i]].color;


        }
    }
    void ErasePictureCompetitive()
    {
        for (int i = 0; i < competitivePicture.Length; i++)
        {
            competitivePicture[i].SetActive(false);
        }
    }
    void ResetPictureCompetitive()
    {
        for (int i = 0; i < matirialFigureCompetitive.Length; i++)
        {
            matirialFigureCompetitive[i].color = noCollorPictureCompetitive.color;

        }
    }
    public void CompareFiguresCollor()
    {
        if(DataPintura.enablePicture)
        {
            for (int i = 0; i < matirialFigureCompetitive.Length; i++)
            {
                if (DataPintura.vectorCollorSelect[i] == DataPintura.vectorComparisonPainting[i])
                {
                    comparePictures++;
                }

            }
            Debug.Log((float)materialPictureCompetitive.Length * 0.7f);
            percetageVictory = (float)materialPictureCompetitive.Length * 0.7f;
            if (comparePictures >= (int)percetageVictory)
            {
                Debug.Log("ganhou acertou " + ((float)comparePictures / (float)materialPictureCompetitive.Length) * 100); //TODO
                comparePictures = 0;
                DataPintura.startGamePicture = false;

            }
            else
            {
                Debug.Log("perdeu");//TODO
                DataPintura.startGamePicture = false;
                comparePictures = 0;
            }
        }
    }    
}


