using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandonPositions : MonoBehaviour
{
    public static int okPieces;

    public int index;
    public float time;
    public bool saveIndex = false;
    public Image bookScore;
    public ParticleSystem particle;
    public List<Sprite> spriteFull;
    public Vector3[] vectorPositions;
    public List<int> randonIndiceList;
    public SpriteRenderer spriteRenderer;
    public Transform[] randonPositions, originalPosition;
    public GameObject buttonRestart, buttonSelect, bookPointsAnim;
    public Sprite[] spritePieces1, spritePieces2, spritePieces3;
    public TextMeshProUGUI timeConter, minTimeCont, gameOverText, winGameText;

    private int timeInt, pauseTime, min, len;
    private bool startGame, randomSprite, transprent, gameOver, goToMapOk, repet;
    void Start()
    {
        goToMapOk = true;
        okPieces = 0;
        randomSprite = true;
        transprent = true;
        //winGameText.enabled = false;
        //gameOverText.enabled = false;
        pauseTime = 1;
        time = 6;
        timeInt = 6;
        min = 5;

        BooksPonts.pJigsaw = 0;

        StartCoroutine(RandomSprite());
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
        if (startGame)
        {
            ContTime();
        }
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
        transprent = false;
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
    void ChangePices(int selectPiece)
    {
        for (int i = 0; i < randonPositions.Length; i++)
        {
            if (selectPiece == 0)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces1[i];
            }
            if (selectPiece == 1)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces2[i];
            }
            if (selectPiece == 2)
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
            index = UnityEngine.Random.Range(0, spriteFull.Count);
            spriteRenderer.sprite = spriteFull[index];
            yield return new WaitForSeconds(0.1f);
        }
        ChangePices(index);
    }
    void GameOver()
    {
        //gameOverText.enabled = true;
        pauseTime = 0;
        buttonRestart.SetActive(true);
        buttonSelect.SetActive(false);
    }
    void WinGame()
    {
        /*if (index == 0)
        {
            sp1 = true;
        }
        else if (index == 1)
        {
            sp2 = true;
        }
        else if (index == 2)
        {
            sp3 = true;
        }
        if (sp1 && BooksPonts.pJigsaw == 0)
        {
            StartCoroutine(BooksPoints());
            BooksPonts.pJigsaw = 1;
        }
        if (sp2 && BooksPonts.pJigsaw == 0)
        {
            StartCoroutine(BooksPoints());
            BooksPonts.pJigsaw = 1;
        }
        if (sp3 && BooksPonts.pJigsaw == 0)
        {
            StartCoroutine(BooksPoints());
            BooksPonts.pJigsaw = 1;

        }
        if ((sp1 && sp2 || sp1 && sp3 || sp2 && sp3) && BooksPonts.pJigsaw == 1)
        {
            BooksPonts.pJigsaw = 2;
            StartCoroutine(BooksPoints());

        }
        if (sp1 && sp2 && sp3 && BooksPonts.pJigsaw == 2)
        {
            BooksPonts.pJigsaw = 4;
            StartCoroutine(BooksPoints());

            particle.Play();
        }
        Debug.Log(BooksPonts.pJigsaw);

        //winGameText.enabled = true;

        pauseTime = 0;
        buttonRestart.SetActive(true);
        buttonSelect.SetActive(false);*/
    }
    private IEnumerator BooksPoints()
    {
        bookPointsAnim.SetActive(true);

        yield return new WaitForSeconds(0.48f);

        bookPointsAnim.SetActive(false);
        bookScore.fillAmount += 0.4f;
    }
    public void Restart()
    {
        SceneManager.LoadScene("JogoQuebraCabeça");
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
