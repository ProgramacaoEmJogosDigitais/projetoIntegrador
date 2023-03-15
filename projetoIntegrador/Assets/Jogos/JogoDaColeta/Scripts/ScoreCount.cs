using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public TextMeshProUGUI score_txt;
    public void Score (ObjectsFalling points)
    {
        score_txt.text = "Pontuação:" + points.ToString();
    }
}
