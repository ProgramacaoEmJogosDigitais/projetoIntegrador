using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeConterPicture : MonoBehaviour
{

    public float timeFigure;
    public int timeFigureint,numberTimeFigure,endTimepictureFigure;
    public TextMeshProUGUI txtContageFigure, txtContageGameFigure;
    public GameObject contageTxt,contageTxtGame,popUpEndGamePicture;
  //  public int regressiveContage;
    // Start is called before the first frame update
    void Start()
    {
        DataPintura.numberTimeFigureData = numberTimeFigure;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(DataPintura.startGamePicture)
        {
            timeFigure += Time.fixedDeltaTime;
            timeFigureint = (int)timeFigure;
            txtContageGameFigure.text = (timeFigureint - numberTimeFigure).ToString();
            if (timeFigureint < numberTimeFigure)
            {


                DataPintura.contageFigureResete = timeFigureint;
                txtContageFigure.text = timeFigureint.ToString();
                contageTxt.SetActive(true);
                contageTxtGame.SetActive(false);
                DataPintura.enablePicture = false;

            }

            if (timeFigureint == numberTimeFigure)
            {
                txtContageFigure.text = timeFigureint.ToString();
                DataPintura.enablePicture = true;
                contageTxt.SetActive(false);
                contageTxtGame.SetActive(true);

                DataPintura.contageFigureResete = timeFigureint;

            }
            if(endTimepictureFigure==timeFigureint-numberTimeFigure-1)
            {
                popUpEndGamePicture.SetActive(true);
                DataPintura.startGamePicture = false;
                DataPintura.enablePicture = false;
                contageTxtGame.SetActive(false);


            }
         
        }
       
       
    }
    public void RestartFigureCompetitive()
    {
        timeFigure = 0;
        timeFigureint = 0;
        DataPintura.startGamePicture = false;
        DataPintura.enablePicture=false;    
        DataPintura.contageFigureResete = 0;
        popUpEndGamePicture.SetActive(false);

    }
   
}
