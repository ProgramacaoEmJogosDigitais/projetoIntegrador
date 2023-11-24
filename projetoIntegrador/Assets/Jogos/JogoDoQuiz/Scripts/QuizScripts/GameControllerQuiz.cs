using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerQuiz : MonoBehaviour
{
    public Image[] botao;

    public GameObject gameOverQuiz;
    public TMP_Text pergunta;
    public TMP_Text respostaA;
    public TMP_Text respostaB;
    public TMP_Text respostaC;
    public TMP_Text respostaD;
    public TMP_Text infoRespostas;
    public TMP_Text pontuacao;
    public bool over;
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

    private int idPergunta;

    private float acertos;
    private float questoes;
    private float erros;
    private bool verificacao_acerto;
    private bool verificacao_pergunta = true;

    void Start()
    {
        over = false;
        gameOverQuiz.SetActive(false);
        idPergunta = 0;
        questoes = perguntas.Length;

        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];
        infoRespostas.text = "Pergunta: " + (idPergunta + 1).ToString() + "/" + questoes.ToString();
    }

    void Update()
    {
        GameOver();
    }

    public void resposta(string alternativa)
    {
        if (verificacao_pergunta)
        {
            StartCoroutine(Espera());
            verificacao_pergunta = false;

            if (alternativa == "A")
            {
                if (alternativaA[idPergunta] == corretas[idPergunta])
                {
                    StartCoroutine(PiscaBotao(Color.white, Color.green, botao[0]));
                    acertos++;
                }
                else
                {
                    StartCoroutine(PiscaBotao(Color.white, Color.green, botao[AchaCerta()]));
                    StartCoroutine(PiscaBotao(Color.white, Color.red, botao[0]));
                    erros++;
                }
            }
            else if (alternativa == "B")
            {
                if (alternativaB[idPergunta] == corretas[idPergunta])
                {
                    StartCoroutine(PiscaBotao(Color.white, Color.green, botao[1]));
                    acertos++;
                }
                else
                {
                    StartCoroutine(PiscaBotao(Color.white, Color.red, botao[1]));
                    StartCoroutine(PiscaBotao(Color.white, Color.green, botao[AchaCerta()]));
                    erros++;
                }
            }
            else if (alternativa == "C")
            {
                if (alternativaC[idPergunta] == corretas[idPergunta])
                {
                    StartCoroutine(PiscaBotao(Color.white, Color.green, botao[2]));
                    acertos++;
                }
                else
                {
                    StartCoroutine(PiscaBotao(Color.white, Color.red, botao[2]));
                    StartCoroutine(PiscaBotao(Color.white, Color.green, botao[AchaCerta()]));
                    erros++;
                }
            }
            else if (alternativa == "D")
            {
                if (alternativaD[idPergunta] == corretas[idPergunta])
                {
                    StartCoroutine(PiscaBotao(Color.white, Color.green, botao[3]));
                    acertos++;
                }
                else
                {
                    StartCoroutine(PiscaBotao(Color.white, Color.red, botao[3]));
                    StartCoroutine(PiscaBotao(Color.white, Color.green, botao[AchaCerta()]));
                    erros++;
                }
            }
        }
    }

    void GameOver()
    {
        if (erros == 3)
        {
            over = true;
            StartCoroutine(Espera2());
            pontuacao.text = "Perguntas Corretas : " + acertos.ToString() + "/" + questoes.ToString();
        }
    }

    void ProximaPergunta()
    {
        if (over)
        {
            GameOver();
        }
        else if (!over)
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
                verificacao_pergunta = true;
            }
            else
            {
                StartCoroutine(Espera2());
                pontuacao.text = "Perguntas Corretas : " + acertos.ToString() + "/" + questoes.ToString();
            }
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
        ProximaPergunta();
    }

    private IEnumerator Espera2()
    {
        yield return new WaitForSeconds(1);
        gameOverQuiz.SetActive(true);
    }

    public int AchaCerta()
    {
        if (corretas[idPergunta] == alternativaA[idPergunta])
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
