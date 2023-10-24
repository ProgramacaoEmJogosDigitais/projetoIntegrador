using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System.Timers;
using UnityEngine.InputSystem;
using UnityEngine.Networking.PlayerConnection;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private float textSpeed = 0.1f; //Velocidade de digita��o do texto

    private float textTimer = 0.0f; //Temporizador para a velocidade de digita��o

    public GameObject player;
    public Canvas canvas;
    public Image imageText; //Imagem fudo do texto
    public Image imageComponent; //Componente que vai receber as imagens
    public List<Sprite> images; //Lista de imagens
    public List<string> texts; //Lista de textos
    public TextMeshProUGUI textComponent; //Componente de texto
    public int currentCharIndex = 0;
    public int currentIndex = 0; //�ndice atual

    private int cont = 0;
    public bool completedText = false;
    void Awake()
    {
        imageComponent.sprite = images[currentIndex];
    }

    void Update()
    {
        cont++;
        if (cont == 1)
        {
            player.GetComponent<VanMoviment>().enabled = false;
        }

        imageComponent.sprite = images[currentIndex]; //Atualiza a imagem atual

        if (textComponent.text == texts[currentIndex] && Input.GetKeyDown(KeyCode.Space))
        {
            currentCharIndex = 0;
            currentIndex++;
            textTimer = 0.0f; //Reinicia o temporizador
            completedText = false;
            if (currentIndex >= images.Count)
            {
                //Configura a imagem, o but�o e o texto como invis�veis
                canvas.gameObject.SetActive(false);
                currentCharIndex = 0;
                currentIndex = 0;
                cont = 0;
                completedText = false;
                player.GetComponent<VanMoviment>().enabled = true;
            }
        }
        else if (textComponent.text != texts[currentIndex] && Input.GetKeyDown(KeyCode.Space))
        {
            completedText = true;
            textComponent.text = texts[currentIndex];
        }
        if (texts.Count != 0 && !completedText)
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
    /*private void PositionsImage() //Altera��o de posi��o e alfa da imagem e texto atual
    {
        float xPositionImage = currentIndex % 2 == 0 ? -614.42f : 550;
        float xPositionText = currentIndex % 2 == 0 ? 49 : -163;
        imageComponent.rectTransform.anchoredPosition = new Vector2(xPositionImage, imageComponent.rectTransform.anchoredPosition.y);
        textComponent.rectTransform.anchoredPosition = new Vector2(xPositionText, textComponent.rectTransform.anchoredPosition.y);
    }*/
}