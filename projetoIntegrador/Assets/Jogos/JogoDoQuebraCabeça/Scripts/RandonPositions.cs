using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandonPositions : MonoBehaviour
{
    public static int okPieces;
    public int index, indexBooks = 0, reset = 0;
    public float time;
    public bool isPlay = false;
    public bool saveIndex = false;
    public bool pause = false;
    public Image bookScore;
    public ParticleSystem particle;
    public List<SpriteRenderer> books;
    public List<Sprite> spriteFull;
    public GameObject canvasWinGame, canvasGameOver;
    public List<Sprite> spriteFullReserve;
    public Vector3[] vectorPositions;
    public List<int> randonIndiceList;
    public SpriteRenderer spriteRenderer;
    public Transform[] randonPositions, originalPosition;
    public GameObject bookPointsAnim, buttonPause, panelPieces;
    public Sprite[] spritePieces1, spritePieces2, spritePieces3, spritePieces4;
    public TextMeshProUGUI secTime, minTime;

    private string namePieces;
    private int indexReserve, min, len;
    private bool startGame, randomSprite, gameOver, goToMapOk;

    void Start()
    {
        indexBooks = PlayerPrefs.GetInt("numBooks");
        Books();
        FirstTime();
        goToMapOk = true;
        okPieces = 0;
        randomSprite = true;
        min = 5;

        BooksPonts.pJigsaw = 0;

        reset = PlayerPrefs.GetInt("reset");
        if (reset == 1)
        {
            namePieces = PlayerPrefs.GetString("nameSprite");
            for (int i = 0; i < spriteFull.Count; i++)
            {
                if (namePieces == spriteFull[i].name)
                {
                    index = i;
                }
            }

            StartPiece(); // Iniciar peças imediatamente
            ShowSprite(); // Tornar a imagem transparente imediatamente
            time = 60;
            PlayerPrefs.SetInt("reset", 0);
            PlayerPrefs.Save();

            UpdateParts();
        }
        else if (indexBooks == 4)
        {
            min = 0;

            for (int i = 0; i < spriteFullReserve.Count; i++)
            {
                spriteFull.Add(spriteFullReserve[i]);
            }
            panelPieces.SetActive(true);
        }
        else
        {
            RandomSprite();
        }
    }

    void Update()
    {
        if (BooksPonts.pJigsaw == 4 && goToMapOk)
        {
            goToMapOk = false;
            StartCoroutine(UpDown());
        }
    }

    private void FixedUpdate()
    {
        if (okPieces >= 24)
        {
            WinGame();
        }
        else if (startGame && !pause)
        {
            ContTime();
        }
    }

    public void BtnNumBook(string sceneName)
    {
        if (indexBooks >= 0 && indexBooks <=3)
        {
            Debug.Log("Antes: "+indexBooks);
            indexBooks++;
            Debug.Log("Depois"+indexBooks);
            PlayerPrefs.SetInt("numBooks", indexBooks);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(sceneName);
    }

    public void BtnReset(string sceneName)
    {
        PlayerPrefs.SetInt("reset", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(sceneName);
    }

    public void RandonPiece()
    {
        for (int j = 0; j < randonPositions.Length; j++)
        {
            vectorPositions[j] = randonPositions[randonIndiceList[j]].position;
        }
        for (int i = 0; i < randonPositions.Length; i++)
        {
            randonPositions[i].position = vectorPositions[i];
        }
    }

    void ContTime()
    {
        time -= Time.deltaTime;

        int seconds = Mathf.FloorToInt(Mathf.Max(time, 0) % 60); // Garante que os segundos não sejam negativos

        secTime.text = seconds.ToString("00");

        if (time <= 0)
        {
            time = 59.999f; // Evita que o tempo fique em 60 segundos

            if (min > 0)
            {
                min--;

                minTime.text = min.ToString("00");
            }
            else
            {
                StopPiece();
                GameOver();
            }
        }
    }

    void ShowSprite()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.3f);
        min = 4;
        time = 60;
        minTime.text = min.ToString();
    }

    public void StopPiece()
    {
        for (int i = 0; i < randonPositions.Length; i++)
        {
            randonPositions[i].gameObject.GetComponent<DragEndDrop>().blockMove = false;
        }
    }

    public void StartPiece()
    {
        for (int i = 0; i < randonPositions.Length; i++)
        {
            randonPositions[i].gameObject.GetComponent<DragEndDrop>().blockMove = true;
        }
    }

    public IEnumerator RandSpriteButton()
    {
        yield return new WaitForSeconds(0.002f);
        randomSprite = false;
        StartPiece(); // Iniciar peças imediatamente
        ShowSprite(); // Tornar a imagem transparente imediatamente
        time = 60;
    }

    void ChangePieces(string namePieces)
    {
        for (int i = 0; i < randonPositions.Length; i++)
        {
            if (namePieces == spriteFullReserve[0].name)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces1[i];
            }
            else if (namePieces == spriteFullReserve[1].name)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces2[i];
            }
            else if (namePieces == spriteFullReserve[2].name)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces3[i];
            }
            else if (namePieces == spriteFullReserve[3].name)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces4[i];
            }
        }
        startGame = true;
        RandonPiece();
    }
    public void BtnOptionPieces(int numImage)
    {
        index = numImage;
        namePieces = spriteFull[index].name;
        startGame = true;
        RandonPiece();
        spriteRenderer.sprite = spriteFull[index];
        ChangePieces(namePieces);
    }

    public void RandomSprite()
    {
        index = UnityEngine.Random.Range(0, spriteFull.Count);
        Debug.Log("index" + index);
        UpdateParts();
    }

    public void UpdateParts()
    {
        namePieces = spriteFull[index].name;

        PlayerPrefs.SetString("nameSprite", namePieces);
        PlayerPrefs.Save();

        spriteRenderer.sprite = spriteFull[index];
        ChangePieces(namePieces);
    }

    void GameOver()
    {
        canvasGameOver.SetActive(true);
        pause = true;
        buttonPause.SetActive(false);
    }

    void WinGame()
    {
        canvasWinGame.SetActive(true);
        pause = true;
        buttonPause.SetActive(false);
    }

    private IEnumerator BooksPoints()
    {
        bookPointsAnim.SetActive(true);
        yield return new WaitForSeconds(0.48f);
        bookPointsAnim.SetActive(false);
        bookScore.fillAmount += 0.4f;
    }

    private IEnumerator UpDown()
    {
        while (true)
        {
            bookScore.transform.localScale = bookScore.transform.localScale * 1.2f;
            yield return new WaitForSeconds(1);
            bookScore.transform.localScale = bookScore.transform.localScale / 1.2f;
        }
    }
    public void Books()
    {
        Color colorBook = new Color(books[0].GetComponent<SpriteRenderer>().color.r, books[0].GetComponent<SpriteRenderer>().color.g, books[0].GetComponent<SpriteRenderer>().color.b);
        colorBook.a = 1;

        if (indexBooks == 1)
        {
            books[0].GetComponent<SpriteRenderer>().color = colorBook;
        }
        else if (indexBooks == 2)
        {
            books[0].GetComponent<SpriteRenderer>().color = colorBook;
            books[1].GetComponent<SpriteRenderer>().color = colorBook;
        }
        else if (indexBooks == 3)
        {
            books[0].GetComponent<SpriteRenderer>().color = colorBook;
            books[1].GetComponent<SpriteRenderer>().color = colorBook;
            books[2].GetComponent<SpriteRenderer>().color = colorBook;
        }
        else if (indexBooks == 4)
        {
            books[0].GetComponent<SpriteRenderer>().color = colorBook;
            books[1].GetComponent<SpriteRenderer>().color = colorBook;
            books[2].GetComponent<SpriteRenderer>().color = colorBook;
            books[3].GetComponent<SpriteRenderer>().color = colorBook;
        }
    }

    void ChangePices(string namePieces)
    {
        for (int i = 0; i < randonPositions.Length; i++)
        {
            if (namePieces == spriteFullReserve[0].name)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces1[i];
            }
            if (namePieces == spriteFullReserve[1].name)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces2[i];
            }
            if (namePieces == spriteFullReserve[2].name)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces3[i];

            }
            if (namePieces == spriteFullReserve[3].name)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces4[i];

            }
        }
        startGame = true;
        RandonPiece();
    }

    public void StartpPiece()
    {
        for (int i = 0; i < randonPositions.Length; i++)
        {
            randonPositions[i].gameObject.GetComponent<DragEndDrop>().blockMove = true; ;
        }
    }
    private void FirstTime()
    {
        if (!PlayerPrefs.HasKey("PastRoundJJigsaw") && !PlayerPrefs.HasKey("CollectedBooksJJigsaw"))
        {
            PlayerPrefs.SetInt("PastRoundJJigsaw", 0);
            PlayerPrefs.SetInt("CollectedBooksJJigsaw", 0);
            PlayerPrefs.Save();
        }
    }
    public void SaveBooksExit()
    {
        if (indexBooks > PlayerPrefs.GetInt("PastRoundJJigsaw"))
        {
            PlayerPrefs.SetInt("PastRoundJJigsaw", indexBooks);
            PlayerPrefs.SetInt("CollectedBooksJJigsaw", indexBooks);
            PlayerPrefs.Save();
        }
    }
}
