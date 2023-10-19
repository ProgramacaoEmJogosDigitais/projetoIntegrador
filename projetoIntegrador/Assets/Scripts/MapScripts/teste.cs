using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            BooksPonts.pQuiz++;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            BooksPonts.pWaterfish++;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            BooksPonts.pParkRun++;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            BooksPonts.pJigsaw++;
        }
    }
}
