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
    public GameObject canvasWinGame;
    public List<Sprite> spriteFullReserve;
    public Vector3[] vectorPositions;
    public List<int> randonIndiceList;
    public SpriteRenderer spriteRenderer;
    public Transform[] randonPositions, originalPosition;
    public GameObject buttonRestart, buttonSelect, bookPointsAnim, buttonPause;
    public Sprite[] spritePieces1, spritePieces2, spritePieces3;
    public TextMeshProUGUI timeConter, minTimeCont, gameOverText, winGameText;

    private string namePieces;
    private int indexReserve, timeInt, pauseTime, min, len;
    private bool startGame, randomSprite, gameOver, goToMapOk;

    private void Awake()
    {
        indexBooks = PlayerPrefs.GetInt("numBooks");

        Books();

        for (int i = 0; i < spriteFull.Count; i++)
        {
            spriteFullReserve.Add(spriteFull[i]);
        }
    }
    void Start()
    {
        goToMapOk = true;
        okPieces = 0;
        randomSprite = true;
        //winGameText.enabled = false;
        //gameOverText.enabled = false;
        pauseTime = 1;
        time = 6;
        timeInt = 6;
        min = 5;

        BooksPonts.pJigsaw = 0;

        reset = PlayerPrefs.GetInt("reset");
        if (reset == 1)
        {
            index = PlayerPrefs.GetInt("numReset");

            StartpPiece(); // Iniciar peças imediatamente
            ShowSprite(); // Tornar a imagem transparente imediatamente
            time = 60;
            timeInt = 60;

            PlayerPrefs.SetInt("reset", 0);
            PlayerPrefs.Save();

            UpdateParts();
        }
        else
        {
            StartCoroutine(RandomSprite());
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
            canvasWinGame.SetActive(true);
            buttonPause.SetActive(false);
            pause = true;
        }
        if (startGame && !pause)
        {
            ContTime();
        }
    }
    public void BtnNumBook(string sceneName)
    {
        if (indexBooks >= 0 && indexBooks <= 4)
        {
            indexBooks++;
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
        time -= Time.deltaTime * pauseTime;
        timeInt = Mathf.FloorToInt(time);
        timeConter.text = timeInt.ToString();

        if (timeInt <= 0)
        {
            time = 60;
            timeInt = 60;
            min--;
            minTimeCont.text = min.ToString();
        }
        if (min <= 0)
        {
            StopPiece();
            GameOver();
        }
    }
    void ShowSprite()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.3f);
        min = 4;
        time = 60;
        minTimeCont.text = min.ToString();
    }
    public void StopPiece()
    {
        for (int i = 0; i < randonPositions.Length; i++)
        {
            randonPositions[i].gameObject.GetComponent<DragEndDrop>().blockMove = false;
        }
    }
    public void StartpPiece()
    {
        for (int i = 0; i < randonPositions.Length; i++)
        {
            randonPositions[i].gameObject.GetComponent<DragEndDrop>().blockMove = true; ;
        }
    }

    public IEnumerator RandSpriteButton()
    {
        yield return new WaitForSeconds(3f);
        randomSprite = false;
        StartpPiece(); // Iniciar peças imediatamente
        ShowSprite(); // Tornar a imagem transparente imediatamente
        time = 60;
        timeInt = 60;
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
        }
        startGame = true;
        RandonPiece();
    }
    public IEnumerator RandomSprite()
    {
        while (randomSprite)
        {
            indexReserve = UnityEngine.Random.Range(0, spriteFullReserve.Count);
            spriteRenderer.sprite = spriteFullReserve[indexReserve];
            index = UnityEngine.Random.Range(0, spriteFull.Count);
            yield return new WaitForSeconds(0.1f);
        }
        PlayerPrefs.SetInt("numReset", index);
        PlayerPrefs.Save();
        UpdateParts();

    }
    public void UpdateParts()
    {
        namePieces = spriteFull[index].name;
        spriteRenderer.sprite = spriteFull[index];
        ChangePices(namePieces);
    }
    void GameOver()
    {
        //gameOverText.enabled = true;
        pauseTime = 0;
        buttonRestart.SetActive(true);
        buttonSelect.SetActive(false);
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
}
