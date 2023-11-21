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
    public GameObject player;
    public GameObject space;
    public Canvas canvas;
    public List<Sprite> images; 
    public List<string> texts; 
    public TextMeshProUGUI textComponent;
    public int currentCharIndex = 0;
    public int currentIndex = 0; 
    public GameObject button;
    public bool completedText = false, startLeft = false;
    public Image panel;
    public Attractions attractions;
    private int cont = 0;
    private float textSpeed = 0.04f;
    private bool withBtn = false;
    private float textTimer = 0.0f; 

    void Awake()
    {
        GetComponent<Image>().sprite = images[currentIndex];
    }
    void Start()
    {
        if (startLeft)
        {
            GetComponent<Animator>().SetBool("dialogueRight", false);
            GetComponent<Animator>().SetBool("dialogueLeft", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("dialogueRight", true);
            GetComponent<Animator>().SetBool("dialogueLeft", false);
        }

    }

    void Update()
    {
        cont++;
        if (cont == 1)
        {
            player.GetComponent<VanMoviment>().enabled = false;
        }

        if (!withBtn)
        {
            GetComponent<Image>().sprite = images[currentIndex]; //Atualiza a imagem atual

            if (textComponent.text == texts[currentIndex] && Input.GetKeyDown(KeyCode.Space))
            {
                currentCharIndex = 0;
                currentIndex++;
                textTimer = 0.0f; //Reinicia o temporizador
                completedText = false;
                NextDialogue();

                if (currentIndex >= images.Count && button != null)
                {
                    textComponent.text = " ";
                    button.SetActive(true);
                    space.SetActive(false);
                    withBtn = true;
                }
                else if (currentIndex >= images.Count)
                {
                    CloseDialogue();
                }
            }
            else if (textComponent.text != texts[currentIndex] && Input.GetKeyDown(KeyCode.Space))
            {
                completedText = true;
                textComponent.text = texts[currentIndex];
            }

            if (texts.Count != 0 && !completedText && !withBtn)
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
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CloseDialogue();
            }
        }
    }
    public void NextDialogue()
    {
        if (currentIndex % 2 == 0)
        {
            if (attractions == Attractions.Museu && currentIndex == 4)
            {
                GetComponent<Animator>().SetBool("dialogueLeft", true);
                GetComponent<Animator>().SetBool("dialogueRight", false);
            }
            else 
            {
                GetComponent<Animator>().SetBool("dialogueRight", true);
                GetComponent<Animator>().SetBool("dialogueLeft", false);
            }
        }
        else
        {
            if (attractions == Attractions.Aquario && currentIndex == 9)
            {
                GetComponent<Animator>().SetBool("dialogueRight", true);
                GetComponent<Animator>().SetBool("dialogueLeft", false);
            }
            else
            {
                GetComponent<Animator>().SetBool("dialogueLeft", true);
                GetComponent<Animator>().SetBool("dialogueRight", false);
            }
        }
    }
    public void CloseDialogue()
    {
        canvas.gameObject.SetActive(false);
        currentCharIndex = 0;
        currentIndex = 0;
        cont = 0;
        completedText = false;
        player.GetComponent<VanMoviment>().enabled = true;
        panel.gameObject.SetActive(false);
        if (button != null)
        {
            space.SetActive(true);
            button.SetActive(false);
            withBtn = false;
        }
    }
    public enum Attractions
    {
        Aquario,
        Museu,
        Default
    }
}