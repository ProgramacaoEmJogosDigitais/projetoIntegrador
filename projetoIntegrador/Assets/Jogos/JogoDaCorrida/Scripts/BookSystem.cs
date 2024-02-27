using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BookSystem : MonoBehaviour
{
    //A cada 300 pontos ganha um livro
    public float metaTakeBook;
    public float increaseMetaTakeBook;
    public List<SpriteRenderer> spriteBook; //lista de livros/sprites da cena
    public int nBooksJCorrida;
    private MovimentPlayer movimentPlayerScript;
    private GameControllerJCorrida gameControllerJCorridaScript;

    private void Awake()
    {
        nBooksJCorrida = 0;
        FirstTime();
        PaintBooks();

    }
    private void Start()
    {
        movimentPlayerScript = FindObjectOfType<MovimentPlayer>();
        gameControllerJCorridaScript = FindObjectOfType<GameControllerJCorrida>();
    }

    private void FixedUpdate()
    {
        Color colorBook = new Color(spriteBook[0].GetComponent<SpriteRenderer>().color.r, spriteBook[0].GetComponent<SpriteRenderer>().color.g, spriteBook[0].GetComponent<SpriteRenderer>().color.b);
        colorBook.a = 1;

        if (nBooksJCorrida == 1)
        {
            spriteBook[0].GetComponent<SpriteRenderer>().color = colorBook;
        }
        else if (nBooksJCorrida == 2)
        {
            spriteBook[0].GetComponent<SpriteRenderer>().color = colorBook;
            spriteBook[1].GetComponent<SpriteRenderer>().color = colorBook;
        }
        else if (nBooksJCorrida == 3)
        {
            spriteBook[0].GetComponent<SpriteRenderer>().color = colorBook;
            spriteBook[1].GetComponent<SpriteRenderer>().color = colorBook;
            spriteBook[2].GetComponent<SpriteRenderer>().color = colorBook;
        }
        else if (nBooksJCorrida == 4)
        {
            spriteBook[0].GetComponent<SpriteRenderer>().color = colorBook;
            spriteBook[1].GetComponent<SpriteRenderer>().color = colorBook;
            spriteBook[2].GetComponent<SpriteRenderer>().color = colorBook;
            spriteBook[3].GetComponent<SpriteRenderer>().color = colorBook;
        }
    }
    void Update()
    {
        if (movimentPlayerScript.distance >= metaTakeBook && nBooksJCorrida < 4)
        {
            nBooksJCorrida++;
            metaTakeBook += increaseMetaTakeBook;
        }
        if (gameControllerJCorridaScript.gameOver)
        {
            if(nBooksJCorrida > PlayerPrefs.GetInt("PastRoundJCorrida"))
            {
                PlayerPrefs.SetInt("CollectedBooksJCorrida", nBooksJCorrida);
                PlayerPrefs.SetInt("PastRoundJCorrida", nBooksJCorrida);
                PlayerPrefs.Save();
            }
        }
    }
    private void FirstTime()
    {
        if (!PlayerPrefs.HasKey("PastRoundJCorrida") && !PlayerPrefs.HasKey("CollectedBooksJCorrida"))
        {
            PlayerPrefs.SetInt("CollectedBooksJCorrida", 0);
            PlayerPrefs.SetInt("PastRoundJCorrida", 0);
            PlayerPrefs.Save();
        }
    }
    private void PaintBooks()
    {
        Color colorBook = new Color(spriteBook[0].GetComponent<SpriteRenderer>().color.r, spriteBook[0].GetComponent<SpriteRenderer>().color.g, spriteBook[0].GetComponent<SpriteRenderer>().color.b);
        colorBook.a = 1;

        if (PlayerPrefs.GetInt("PastRoundJCorrida") == 1)
        {
            spriteBook[0].GetComponent<SpriteRenderer>().color = colorBook;
        }
        else if (PlayerPrefs.GetInt("PastRoundJCorrida") == 2)
        {
            spriteBook[0].GetComponent<SpriteRenderer>().color = colorBook;
            spriteBook[1].GetComponent<SpriteRenderer>().color = colorBook;
        }
        else if (PlayerPrefs.GetInt("PastRoundJCorrida") == 3)
        {
            spriteBook[0].GetComponent<SpriteRenderer>().color = colorBook;
            spriteBook[1].GetComponent<SpriteRenderer>().color = colorBook;
            spriteBook[2].GetComponent<SpriteRenderer>().color = colorBook;
        }
        else if (PlayerPrefs.GetInt("PastRoundJCorrida") == 4)
        {
            spriteBook[0].GetComponent<SpriteRenderer>().color = colorBook;
            spriteBook[1].GetComponent<SpriteRenderer>().color = colorBook;
            spriteBook[2].GetComponent<SpriteRenderer>().color = colorBook;
            spriteBook[3].GetComponent<SpriteRenderer>().color = colorBook;
        }
    }
}