using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CabineSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject attraction0;
    public GameObject attraction1;
    public GameObject attraction2;
    public Canvas popUpCabineCanva;
    public GameObject booksScene;

    //public List<SpriteRenderer> BooksSprites; //Lista de livros

    //quebra cabeca
    //quiz
    //corrida
    //coleta /Aquario

    private bool isColliding = false;
    private VanMoviment playerScript;

    public List<SpriteRenderer> booksQuebraCabeca;
    public List<SpriteRenderer> booksQuiz;
    public List<SpriteRenderer> booksCorrida;
    public List<SpriteRenderer> booksAquario;

    private int jQuebraCabeca;
    private int jQuiz;
    private int jCorrida;
    private int jAquario;

    private void Start()
    {
        playerScript = FindObjectOfType<VanMoviment>();

        jQuebraCabeca = PlayerPrefs.GetInt("numBooks");
        jQuiz = PlayerPrefs.GetInt("QuizBooks");
        jCorrida = PlayerPrefs.GetInt("CollectedBooksJCorrida");
        jAquario = PlayerPrefs.GetInt("");

        //SepareteBooks();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (attraction1 != null)
            {
                attraction0.gameObject.SetActive(true);
                attraction1.gameObject.SetActive(false);
                attraction2.gameObject.SetActive(false);
            }
            else
            {
                attraction0.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            isColliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (attraction1 != null)
            {
                attraction0.gameObject.SetActive(false);
                attraction1.gameObject.SetActive(true);
                attraction2.gameObject.SetActive(true);
            }
            else
            {
                attraction0.transform.localScale = new Vector3(1, 1, 1);
            }
            isColliding = false;
        }
    }

    private void Update()
    {
        if (isColliding)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !playerScript.isMoving)
            {
                player.GetComponent<VanMoviment>().enabled = false;
                popUpCabineCanva.gameObject.SetActive(true);
                booksScene.SetActive(true);
                CheckBooks();
            }

        }
    }

    public void BackMap()
    {
        popUpCabineCanva.gameObject.SetActive(false);
        booksScene.SetActive(false);
        player.GetComponent<VanMoviment>().enabled=true;
    }

    //private void SepareteBooks()
    //{
    //    for (int i = 0; i < BooksSprites.Count; i++)
    //    {
    //        if (i >= 0 && i <= 3) //quebra cabeca
    //        {
    //            booksQuebraCabeca.Add(BooksSprites[i]);
    //        }
    //        if (i >= 4 && i <= 7)//quiz
    //        {
    //            booksQuiz.Add(BooksSprites[i]);
    //        }
    //        if (i >= 8 && i <= 11)//corrida     
    //        {
    //            booksCorrida.Add(BooksSprites[i]);
    //        }
    //        if (i >= 12 && i <= 15)//coleta /Aquario
    //        {
    //            booksAquario.Add(BooksSprites[i]);
    //        }
    //    }
    //}

    public void CheckBooks()
    {
        Debug.Log("aaa");
        Debug.Log(jCorrida);
        //jQuebraCabeca = PlayerPrefs.GetInt("numBooks");
        //jQuiz = PlayerPrefs.GetInt("QuizBooks");
        //jCorrida = PlayerPrefs.GetInt("CollectedBooksJCorrida");
        //jAquario = PlayerPrefs.GetInt("");


        Color colorBook = new Color(booksQuebraCabeca[0].GetComponent<SpriteRenderer>().color.r, booksQuebraCabeca[0].GetComponent<SpriteRenderer>().color.g, booksQuebraCabeca[0].GetComponent<SpriteRenderer>().color.b);
        colorBook.a = 1;
        colorBook.r = 255;
        colorBook.g = 255;
        colorBook.b = 255;

        
        //quebra cabeca
        //if (PlayerPrefs.GetInt("numBooks") > jQuebraCabeca)
        //{
            if (jQuebraCabeca == 1)
            {
                booksQuebraCabeca[0].GetComponent<SpriteRenderer>().color = colorBook;
            }
            else if (jQuebraCabeca == 2)
            {
                booksQuebraCabeca[0].GetComponent<SpriteRenderer>().color = colorBook;
                booksQuebraCabeca[1].GetComponent<SpriteRenderer>().color = colorBook;
            }
            else if (jQuebraCabeca == 3)
            {
                booksQuebraCabeca[0].GetComponent<SpriteRenderer>().color = colorBook;
                booksQuebraCabeca[1].GetComponent<SpriteRenderer>().color = colorBook;
                booksQuebraCabeca[2].GetComponent<SpriteRenderer>().color = colorBook;
            }
            else if (jQuebraCabeca == 4)
            {
                booksQuebraCabeca[0].GetComponent<SpriteRenderer>().color = colorBook;
                booksQuebraCabeca[1].GetComponent<SpriteRenderer>().color = colorBook;
                booksQuebraCabeca[2].GetComponent<SpriteRenderer>().color = colorBook;
                booksQuebraCabeca[3].GetComponent<SpriteRenderer>().color = colorBook;
            }
        //}

        //quiz
        //if (PlayerPrefs.GetInt("QuizBooks") > jQuiz)
        //{
            if (jQuiz == 1)
            {
                booksQuiz[0].GetComponent<SpriteRenderer>().color = colorBook;
            }
            else if (jQuiz == 2)
            {
                booksQuiz[0].GetComponent<SpriteRenderer>().color = colorBook;
                booksQuiz[1].GetComponent<SpriteRenderer>().color = colorBook;
            }
            else if (jQuiz == 3)
            {
                booksQuiz[0].GetComponent<SpriteRenderer>().color = colorBook;
                booksQuiz[1].GetComponent<SpriteRenderer>().color = colorBook;
                booksQuiz[2].GetComponent<SpriteRenderer>().color = colorBook;
            }
            else if (jQuiz == 4)
            {
                booksQuiz[0].GetComponent<SpriteRenderer>().color = colorBook;
                booksQuiz[1].GetComponent<SpriteRenderer>().color = colorBook;
                booksQuiz[2].GetComponent<SpriteRenderer>().color = colorBook;
                booksQuiz[3].GetComponent<SpriteRenderer>().color = colorBook;
            }
       // }

        //corrida
        //if (PlayerPrefs.GetInt("CollectedBooksJCorrida") > jCorrida)
        //{
            if (jCorrida == 1)
            {
                booksCorrida[0].GetComponent<SpriteRenderer>().color = colorBook;
            }
            else if (jCorrida == 2)
            {
            Debug.Log("ENTROU");
                booksCorrida[0].GetComponent<SpriteRenderer>().color = colorBook;
                booksCorrida[1].GetComponent<SpriteRenderer>().color = colorBook;
            }
            else if (jCorrida == 3)
            {
                booksCorrida[0].GetComponent<SpriteRenderer>().color = colorBook;
                booksCorrida[1].GetComponent<SpriteRenderer>().color = colorBook;
                booksCorrida[2].GetComponent<SpriteRenderer>().color = colorBook;
            }
            else if (jCorrida == 4)
            {
                booksCorrida[0].GetComponent<SpriteRenderer>().color = colorBook;
                booksCorrida[1].GetComponent<SpriteRenderer>().color = colorBook;
                booksCorrida[2].GetComponent<SpriteRenderer>().color = colorBook;
                booksCorrida[3].GetComponent<SpriteRenderer>().color = colorBook;
            }
        //}

        //aquario
        //if (PlayerPrefs.GetInt("CollectedBooksJCorrida") > jCorrida)
        //{
        //    if (jCorrida == 1)
        //    {
        //        booksCorrida[0].GetComponent<Image>().color = colorBook;
        //    }
        //    else if (jCorrida == 2)
        //    {
        //        booksCorrida[0].GetComponent<Image>().color = colorBook;
        //        booksCorrida[1].GetComponent<Image>().color = colorBook;
        //    }
        //    else if (jCorrida == 3)
        //    {
        //        booksCorrida[0].GetComponent<Image>().color = colorBook;
        //        booksCorrida[1].GetComponent<Image>().color = colorBook;
        //        booksCorrida[2].GetComponent<Image>().color = colorBook;
        //    }
        //    else if (jCorrida == 4)
        //    {
        //        booksCorrida[0].GetComponent<Image>().color = colorBook;
        //        booksCorrida[1].GetComponent<Image>().color = colorBook;
        //        booksCorrida[2].GetComponent<Image>().color = colorBook;
        //        booksCorrida[3].GetComponent<Image>().color = colorBook;
        //    }
        //}

    }
}
