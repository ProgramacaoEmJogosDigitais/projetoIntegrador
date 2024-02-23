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
        jAquario = PlayerPrefs.GetInt("CollectedBooksJColeta");

        FirstTime();

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

    public void CheckBooks()
    {
        Color colorBook = new Color(booksQuebraCabeca[0].GetComponent<SpriteRenderer>().color.r, booksQuebraCabeca[0].GetComponent<SpriteRenderer>().color.g, booksQuebraCabeca[0].GetComponent<SpriteRenderer>().color.b);
        colorBook.a = 1;
        colorBook.r = 255;
        colorBook.g = 255;
        colorBook.b = 255;

        CheckQuebraCabeca(colorBook);
        CheckQuiz(colorBook);
        CheckCorrida(colorBook);
        CheckAquario(colorBook);
    }

    private void FirstTime()
    {
        if(!PlayerPrefs.HasKey("QuebraCabecaCabin") && !PlayerPrefs.HasKey("QuizCabin") && !PlayerPrefs.HasKey("CorridaCabin") && !PlayerPrefs.HasKey("AquarioCabin"))
        {
            PlayerPrefs.SetInt("QuebraCabecaCabin", 0);
            PlayerPrefs.SetInt("QuizCabin", 0);
            PlayerPrefs.SetInt("CorridaCabin", 0);
            PlayerPrefs.SetInt("AquarioCabin", 0);
        }
    }

    private void CheckQuebraCabeca(Color colorBook)
    {
        //quebra cabeca
        if (jQuebraCabeca > PlayerPrefs.GetInt("QuebraCabecaCabin"))
        {
            PlayerPrefs.SetInt("QuebraCabecaCabin", jQuebraCabeca);
            PlayerPrefs.Save();

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
        }
        //PINTA A QUANTIDADE QUE JA ESTAVA
        else
        {
            for (int i = 0; i < PlayerPrefs.GetInt("QuebraCabecaCabin"); i++)
            {
                booksQuiz[i].GetComponent<SpriteRenderer>().color = colorBook;
            }
        }
    }
    private void CheckQuiz(Color colorBook)
    {
        //quiz
        if (jQuiz > PlayerPrefs.GetInt("QuizCabin"))
        {
            PlayerPrefs.SetInt("QuizCabin", jQuiz);
            PlayerPrefs.Save();
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
            
            
        }
        //PINTA A QUANTIDADE QUE JA ESTAVA
        else
        {
            for (int i = 0; i < PlayerPrefs.GetInt("QuizCabin"); i++)
            {
                    booksQuiz[i].GetComponent<SpriteRenderer>().color = colorBook;
            }
        }
    }
    private void CheckCorrida(Color colorBook)
    {
        //corrida
        if (jCorrida > PlayerPrefs.GetInt("CorridaCabin"))
        {
            PlayerPrefs.SetInt("CorridaCabin", jCorrida);
            PlayerPrefs.Save();

            if (jCorrida == 1)
            {
                booksCorrida[0].GetComponent<SpriteRenderer>().color = colorBook;
            }
            else if (jCorrida == 2)
            {
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
        }
        //PINTA A QUANTIDADE QUE JA ESTAVA
        else
        {
            for (int i = 0; i < PlayerPrefs.GetInt("CorridaCabin"); i++)
            {
                booksQuiz[i].GetComponent<SpriteRenderer>().color = colorBook;
            }
        }
    }
    private void CheckAquario(Color colorBook)
    {

        //aquario
        if (jAquario > PlayerPrefs.GetInt("AquarioCabin"))
        {
            PlayerPrefs.SetInt("AquarioCabin", jAquario);
            PlayerPrefs.Save();
            if (jAquario == 1)
            {
                booksAquario[0].GetComponent<SpriteRenderer>().color = colorBook;
            }
            else if (jAquario == 2)
            {
                booksAquario[0].GetComponent<SpriteRenderer>().color = colorBook;
                booksAquario[1].GetComponent<SpriteRenderer>().color = colorBook;
            }
            else if (jAquario == 3)
            {
                booksAquario[0].GetComponent<SpriteRenderer>().color = colorBook;
                booksAquario[1].GetComponent<SpriteRenderer>().color = colorBook;
                booksAquario[2].GetComponent<SpriteRenderer>().color = colorBook;
            }
            else if (jAquario == 4)
            {
                booksAquario[0].GetComponent<SpriteRenderer>().color = colorBook;
                booksAquario[1].GetComponent<SpriteRenderer>().color = colorBook;
                booksAquario[2].GetComponent<SpriteRenderer>().color = colorBook;
                booksAquario[3].GetComponent<SpriteRenderer>().color = colorBook;
            }
        }
        //PINTA A QUANTIDADE QUE JA ESTAVA
        else
        {
            for (int i = 0; i < PlayerPrefs.GetInt("AquarioCabin"); i++)
            {
                booksAquario[i].GetComponent<SpriteRenderer>().color = colorBook;
            }
        }
    }
}
