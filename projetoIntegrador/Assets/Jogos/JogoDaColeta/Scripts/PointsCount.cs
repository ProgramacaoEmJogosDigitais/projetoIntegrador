using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public static int points = 0;
    public static TextMeshProUGUI score_txt;

    public static void IncreaseScore()

    {
        points++;
        // Atualize a GUI de pontua��o
        score_txt.text = "Pontua��o: " + points.ToString();
    }

}
