using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeConterPicture : MonoBehaviour
{

    public float timeFigure;
    public int timeFigureint;
    public TextMeshProUGUI txtContageFigure;
    public GameObject contageTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeFigure += Time.fixedDeltaTime;
        timeFigureint=(int)timeFigure;
            
        DataPintura.contageFigureResete = timeFigureint;
        txtContageFigure.text=timeFigureint.ToString();
        if(timeFigureint==10)
        {
            contageTxt.SetActive(false);
        }
    }
   
}
