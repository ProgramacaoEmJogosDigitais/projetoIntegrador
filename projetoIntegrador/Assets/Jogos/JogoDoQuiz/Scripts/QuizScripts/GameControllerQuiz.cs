using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerQuiz : MonoBehaviour
{
    public Image[] botao;
  
    public int idTema;
    public TMP_Text pergunta;
    public TMP_Text respostaA;
    public TMP_Text respostaB;
    public TMP_Text respostaC;
    public TMP_Text respostaD;
    public TMP_Text infoRespostas;
    [TextArea]
    public string[] perguntas;
    [TextArea]
    public string[] alternativaA;
    [TextArea]
    public string[] alternativaB;
    [TextArea]
    public string[] alternativaC;
    [TextArea]
    public string[] alternativaD;
    [TextArea]
    public string[] corretas;
    [TextArea]

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
        infoRespostas.text = "Pergunta: " + (idPergunta + 1).ToString() + "/" + questoes.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void resposta(string alternativa)
    {
        if (alternativa == "A")
        {
            if (alternativaA[idPergunta] == corretas[idPergunta])
            {
                StartCoroutine(PiscaBotao(Color.white, Color.green, botao[0]));
            }
            else
            {
                StartCoroutine(PiscaBotao(Color.white, Color.green, botao[AchaCerta()]));
                StartCoroutine(PiscaBotao(Color.white, Color.red, botao[0]));

            }
        }
        else if (alternativa == "B")
        {
            if (alternativaB[idPergunta] == corretas[idPergunta])
            {
                StartCoroutine(PiscaBotao(Color.white, Color.green, botao[1]));
            }
            else
            {
                StartCoroutine(PiscaBotao(Color.white, Color.red, botao[1]));
                StartCoroutine(PiscaBotao(Color.white, Color.green, botao[AchaCerta()]));
            }
        }
        else if (alternativa == "C")
        {
            if (alternativaC[idPergunta] == corretas[idPergunta])
            {
                StartCoroutine(PiscaBotao(Color.white, Color.green, botao[2]));
            }
            else
            {
                StartCoroutine(PiscaBotao(Color.white, Color.red, botao[2]));
                StartCoroutine(PiscaBotao(Color.white, Color.green, botao[AchaCerta()]));
            }
        }
        else if (alternativa == "D")
        {
            if (alternativaD[idPergunta] == corretas[idPergunta])
            {
                StartCoroutine(PiscaBotao(Color.white, Color.green, botao[3]));
            }
            else
            {
                StartCoroutine(PiscaBotao(Color.white, Color.red, botao[3]));
                StartCoroutine(PiscaBotao(Color.white, Color.green, botao[AchaCerta()]));
            }
        }

        StartCoroutine(Espera());


    }
    void proximaPergunta()
    {
        idPergunta += 1;
        if (idPergunta <= (questoes - 1))
        {


            pergunta.text = perguntas[idPergunta];
            respostaA.text = alternativaA[idPergunta];
            respostaB.text = alternativaB[idPergunta];
            respostaC.text = alternativaC[idPergunta];
            respostaD.text = alternativaD[idPergunta];
            infoRespostas.text = "Pergunta: " + (idPergunta + 1).ToString() + "/" + questoes.ToString();
        }
        else
        {
            idPergunta = 0;
        }

    }
   
    private IEnumerator PiscaBotao(Color corOriginal, Color corPisca, Image botao)
    {
        botao.color = corPisca;
        yield return new WaitForSeconds(1);
        botao.color = corOriginal;
    }

    private IEnumerator Espera()
    {

        yield return new WaitForSeconds(1);
        proximaPergunta();


    }
    public int AchaCerta()
    {
       if (corretas[idPergunta]== alternativaA[idPergunta])
        {
            return 0;
        }
        if (corretas[idPergunta] == alternativaB[idPergunta])
        {
            return 1;
        }
        if (corretas[idPergunta] == alternativaC[idPergunta])
        {
            return 2;
        }
        if (corretas[idPergunta] == alternativaD[idPergunta])
        {
            return 3;
        }
        return 4;



    }

}
   
