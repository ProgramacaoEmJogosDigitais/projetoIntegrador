using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCount : MonoBehaviour
{
    public static int points = 0;
    //public Text guiPontuacao;

    public static void aumentarPontuacao()

    {
        points++;
        // Atualize a GUI de pontua��o
        //guiPontuacao.text = "Pontua��o: " + points.ToString();
    }

}
