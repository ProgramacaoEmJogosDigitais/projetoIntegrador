using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //para poder acessar e editar na unity
public class QuestionData 
{
    public string textQuestion;

    public AnswerData[] answers;
}
