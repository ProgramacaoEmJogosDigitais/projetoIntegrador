using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    public static int points = 0;
    public static TextMeshProUGUI scoreCount_txt;

    public static void IncreaseScore()

    {
        points++;
        // Atualiza a GUI de pontua��o
        scoreCount_txt.text = "Pontua��o: " + points.ToString();
    }

}