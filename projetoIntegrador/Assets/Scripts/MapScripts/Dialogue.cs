using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System.Timers;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private float timeImage = 4.0f; //Tempo da imagem
    [SerializeField] private float textSpeed = 0.1f; //Velocidade de digita��o do texto

    private float textTimer = 0.0f; //Temporizador para a velocidade de digita��o
    private float currentAlpha = 1.0f; //Alfa atual
    private float alphaSpeed = 0.5f; //Velocidade do alfa
    private float timer = 0.0f; //Tempo

    public GameObject player;
    public Canvas canvas;
    public Image imageText; //Imagem fudo do texto
    public Image imageComponent; //Componente que vai receber as imagens
    public List<Sprite> images; //Lista de imagens
    public List<string> texts; //Lista de textos
    public TextMeshProUGUI textComponent; //Componente de texto
    public int currentCharIndex = 0;
    public int currentIndex = 0; //�ndice atual

    void Awake()
    {
        player.GetComponent<VanMoviment>().input.Disable();
        imageComponent.sprite = images[currentIndex];
    }

    void Update()
    {
        PositionsImage();
        timer += Time.deltaTime;// Incremento do temporizador

        //Se o tempo decorrido for maior ou igual ao tempo de exibi��o da imagem atual
        if (timer >= timeImage)
        {
            timer = 0.0f;    //Reinicia o temporizador do texto
            currentCharIndex = 0;
            currentIndex++;    //Avan�a para a pr�xima imagem na lista de imagens

            LastImage();
        }
        imageComponent.sprite = images[currentIndex]; //Atualiza a imagem atual
        //Calcula o alfa (transpar�ncia) da imagem e do texto com base no tempo decorrido desde o in�cio da exibi��o da imagem atual
        if (timer <= alphaSpeed)
        {
            currentAlpha = timer / alphaSpeed; //Define o valor da transpar�ncia atual com base na divis�o do tempo atual pelo tempo de dura��o do fade-in(desapari��o)
        }
        else if (timer >= timeImage - alphaSpeed)
        {
            currentAlpha = (timeImage - timer) / alphaSpeed; //Define o valor da transpar�ncia atual com base na divis�o do tempo restante pelo tempo de dura��o do fade-out(apari��o)
        }

        //Configura o alfa da imagem e do texto
        imageComponent.color = new Color(1.0f, 1.0f, 1.0f, currentAlpha);
        imageText.color = new Color(imageText.color.r, imageText.color.g, imageText.color.b, currentAlpha);


        if (texts.Count != 0)
        {
            //Se ainda houver caracteres do texto para serem exibidos
            if (currentCharIndex < texts[currentIndex].Length)
            {
                textTimer += Time.deltaTime; //Incrementa o temporizador do texto

                if (textTimer >= textSpeed) //Verifica se o atraso foi alcan�ado
                {
                    textTimer = 0.0f; //Reinicia o temporizador
                    currentCharIndex++;    //Incrementa o �ndice do caractere atual
                    textComponent.text = texts[currentIndex].Substring(0, currentCharIndex); //Exibe o texto a partir do primeiro caractere at� o caractere atual
                }
            }
        }
    }
    private void PositionsImage() //Altera��o de posi��o e alfa da imagem e texto atual
    {
        float xPositionImage = currentIndex % 2 == 0 ? -614.42f : 550;
        float xPositionText = currentIndex % 2 == 0 ? 49 : -163;
        imageComponent.rectTransform.anchoredPosition = new Vector2(xPositionImage, imageComponent.rectTransform.anchoredPosition.y);
        textComponent.rectTransform.anchoredPosition = new Vector2(xPositionText, textComponent.rectTransform.anchoredPosition.y);
    }
    private void LastImage()
    {
        //Se o �ndice atual for maior ou igual ao n�mero de imagens na lista
        if (currentIndex >= images.Count)
        {
            if (Time.time > 2.0f)
            {
                currentIndex = images.Count - 1; //Volta um �ndice, ou seja, fica na ultima imagem da lista
                currentAlpha = 0.0f;

                player.GetComponent<VanMoviment>().input.Enable();

                //Configura a imagem, o but�o e o texto como invis�veis
                canvas.gameObject.SetActive(false);
                currentCharIndex = 0;
                currentIndex = 0;
            }
        }
    }
    public void NextImage()
    {
        currentIndex++;
        Debug.Log(currentIndex);

        LastImage();
        PositionsImage();

        //Reseta os valores do texto
        currentCharIndex = 0;
        textComponent.text = "";
        currentAlpha = 1.0f;

        imageComponent.sprite = images[currentIndex]; //Atualiza a imagem atual
    }
}