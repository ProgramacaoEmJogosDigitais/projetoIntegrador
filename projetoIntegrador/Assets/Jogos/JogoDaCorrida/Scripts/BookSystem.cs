using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BookSystem : MonoBehaviour
{
    //A cada 300 pontos anhar um livro
    public float metaTakeBook;
    public float increaseMetaTakeBook;
    public List<SpriteRenderer> spriteBook; //lista de livros/sprites da cena
    public float currentSpeedInfor;
    public int nBooksJCorrida;
    private MovimentPlayer movimentPlayerScript;
    private void Awake()
    {
        nBooksJCorrida = PlayerPrefs.GetInt("CollectedBooksJCorrida", 0);
    }
    private void Start()
    {
        movimentPlayerScript = FindObjectOfType<MovimentPlayer>();
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
            PlayerPrefs.SetInt("CollectedBooksJCorrida", nBooksJCorrida);
            PlayerPrefs.Save();

            metaTakeBook += increaseMetaTakeBook;
        }
    }
}