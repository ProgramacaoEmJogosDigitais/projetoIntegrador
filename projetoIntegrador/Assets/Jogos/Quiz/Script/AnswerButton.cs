using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Text textAnswer;
    private AnswerData answerData;

    public void Setup(AnswerData data)
    {
        answerData = data;
        textAnswer.text = answerData.AnswerText;
    }
}
