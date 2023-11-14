using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerQuiz : MonoBehaviour
{
    public int idTema;
    public TMP_Text pergunta;
    public TMP_Text respostaA;
    public TMP_Text respostaB;
    public TMP_Text respostaC;
    public TMP_Text respostaD;
    public TMP_Text infoRespostas;

    public string[] perguntas;
    public string[] alternativaA;
    public string[] alternativaB;
    public string[] alternativaC;
    public string[] alternativaD;
    public string[] corretas;

    private int idPergunta;

    private float acertos;
    private float questoes;
    void Start()
    {
        idPergunta = 0;
        questoes = perguntas.Length;

        print(questoes);
        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];
        infoRespostas.text = "Respondendo " + (idTema + 1).ToString() + " de " + questoes.ToString() + " perguntas. ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resposta(string alternativa)
    {
        if(alternativa == "A")
        {
            if (alternativaA[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }
       else if(alternativa == "B")
        {
            if (alternativaB[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }
       else if (alternativa == "C")
        {
            if (alternativaC[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }
        else if(alternativa == "D")
        {
            if (alternativaD[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }

        proximaPergunta();

        
    }
    void proximaPergunta()
    {
        idPergunta += 1;
        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];
        infoRespostas.text = "Respondendo " + (idTema + 1).ToString() + " de " + questoes.ToString() + " perguntas. ";
    }
}
