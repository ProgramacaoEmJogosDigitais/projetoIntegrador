using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class SystemBooksJColeta : MonoBehaviour
{
    private int books;
    private GameControllerJC gameControllerJCScript;
    public List<GameObject> booksList;
    public int pontsBook1;
    public int pontsBook2;
    public int pontsBook3;
    public int pontsBook4;

    private void Awake()
    {
        FirstTime();
        books = 0;
    }
    private void Start()
    {
        gameControllerJCScript = GetComponent<GameControllerJC>();
        PaintBooks();

    }
    private void Update()
    {
        GetBooks();
        //if (gameControllerJCScript.gameOver)
        //{
        //    Debug.Log("é pra chamar o metodo: ");
        //    BooksPoints();
        //}
    }
    public void BooksPoints()
    {
            gameControllerJCScript.gameOver = false;
            Debug.Log("Entrou no Metodo2, valor do game over: " + gameControllerJCScript.gameOver);

            int points = 0;
            if (int.TryParse(gameControllerJCScript.score.text, out points))
            {
                Debug.Log("CONSEGUIU CONVERTER, valor dos points: " + points);
                if (points > 0 && points <= pontsBook1 /*2*/) // 1 livro //MUDAR AQUI PARA DEIXAR DE ACORDO CO A PONTUAÇÂO LIMITE DE CADA IVRO
                {
                    books = 1;
                    Debug.Log("111111 Salvou de livros: " + 1);
                    //ta entrando

                }
                if (points > 2 && points <= pontsBook2 /*4*/)// 2 livro
                {
                    books = 2;
                    Debug.Log("222222 Salvou de livros: " + 2);

                }
                if (points > 4 && points <= pontsBook3/*6*/)// 3 livro
                {
                    books = 3;
                    Debug.Log("3333333 Salvou de livros: " + 3);

                }
                if (points > 6 && points <= pontsBook4/*8*/)// 4 livro
                {
                    books = 4;
                    Debug.Log("4444444 Salvou de livros: " + 4);

                }
            SaveBooks();
        }
    }
    private void FirstTime()
    {
        if (!PlayerPrefs.HasKey("PastRoundJColeta") && !PlayerPrefs.HasKey("CollectedBooksJColeta"))
        {
            PlayerPrefs.SetInt("CollectedBooksJColeta", 0);
            PlayerPrefs.SetInt("PastRoundJColeta", 0);
            PlayerPrefs.Save();


        }
    }
    private void SaveBooks()
    {
        if (books > PlayerPrefs.GetInt("PastRoundJColeta"))
        {
            Debug.Log("é MAIOR");
            PlayerPrefs.SetInt("CollectedBooksJColeta", books);
            PlayerPrefs.SetInt("PastRoundJColeta", books);
            PlayerPrefs.Save();
            Debug.Log("Salvou de livros no final: " + books);

        }
        else
        {
            Debug.Log("NAO É MAIOR");
            Debug.Log("livros salvos para ir para o mapa: " + PlayerPrefs.GetInt("CollectedBooksJColeta"));
        }
    }

    private void PaintBooks()
    {
        Debug.Log("PINTAR LIVROS");
        Color colorBook = new Color(booksList[0].GetComponent<SpriteRenderer>().color.r, booksList[0].GetComponent<SpriteRenderer>().color.g, booksList[0].GetComponent<SpriteRenderer>().color.b);
        colorBook.a = 1;

        if (PlayerPrefs.GetInt("CollectedBooksJColeta") == 1)
        {
            Debug.Log("Entrou 1");
            booksList[0].GetComponent<SpriteRenderer>().color = colorBook;
        }
        else if (PlayerPrefs.GetInt("CollectedBooksJColeta") == 2)
        {
            Debug.Log("Entrou 2");
            booksList[0].GetComponent<SpriteRenderer>().color = colorBook;
            booksList[1].GetComponent<SpriteRenderer>().color = colorBook;
        }
        else if (PlayerPrefs.GetInt("CollectedBooksJColeta") == 3)
        {
            Debug.Log("Entrou 3");
            booksList[0].GetComponent<SpriteRenderer>().color = colorBook;
            booksList[1].GetComponent<SpriteRenderer>().color = colorBook;
            booksList[2].GetComponent<SpriteRenderer>().color = colorBook;
        }
        else if (PlayerPrefs.GetInt("CollectedBooksJColeta") == 4)
        {
            Debug.Log("Entrou 4");
            booksList[0].GetComponent<SpriteRenderer>().color = colorBook;
            booksList[1].GetComponent<SpriteRenderer>().color = colorBook;
            booksList[2].GetComponent<SpriteRenderer>().color = colorBook;
            booksList[3].GetComponent<SpriteRenderer>().color = colorBook;
        }
    }

    private void GetBooks()
    {
        Color colorBook = new Color(booksList[0].GetComponent<SpriteRenderer>().color.r, booksList[0].GetComponent<SpriteRenderer>().color.g, booksList[0].GetComponent<SpriteRenderer>().color.b);
        colorBook.a = 1;

        if (FishsFalling.points >= pontsBook1)
        {
            // Define o alpha para 1.0 (transparência de 100%)
            booksList[0].GetComponent<SpriteRenderer>().color = colorBook;
        }
        if (FishsFalling.points >= pontsBook2)
        {
            // Define o alpha para 1.0 (transparência de 100%)
            booksList[1].GetComponent<SpriteRenderer>().color = colorBook;
        }
        if (FishsFalling.points >= pontsBook3)
        {
            // Define o alpha para 1.0 (transparência de 100%)
            booksList[2].GetComponent<SpriteRenderer>().color = colorBook;
        }
        if (FishsFalling.points >= pontsBook4)
        {
            // Define o alpha para 1.0 (transparência de 100%)
            booksList[3].GetComponent<SpriteRenderer>().color = colorBook;
        }
    }
}
