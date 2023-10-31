using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandonPositions : MonoBehaviour
{
    public Transform []randonPositions,originalPosition;
    public Vector3[] vectorPositions;
    public TextMeshProUGUI guideText,timeConter,minTimeCont,gameOverText,winGameText;

    int min;
    public  int randonIndice,len;
    public List<int> randonIndiceList;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spritePieces1,spritePieces2,spritePieces3, spriteFull;
    public static int okPieces;
    int index,pauseTime;
    public float time;
    bool startGame,randomSprite,transprent,gameOver;
    public GameObject buttonRestart, buttonSelect;
    bool sp1, sp2, sp3;
  
    
    public bool repet;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if(okPieces>=24)
        {
            WinGame();
        }
       if(startGame)
        {
            ContTime();
        }
       
    }
    void Start()
    {
        okPieces = 0;
        randomSprite = true;
        transprent = true;
        winGameText.enabled = false;
        gameOverText.enabled = false;
        pauseTime = 1;
        sp1 = false;
        sp2 = false;
        sp3 = false;
        




        StartCoroutine(RandomSprite());






    }
  
   public  void RandonPiece()
    {

        for (int j = 0; j < randonPositions.Length; j++)
        {
            vectorPositions[j] = randonPositions[randonIndiceList[j]].position;
        }



        Debug.Log("1");
        for (int i = 0; i < randonPositions.Length; i++)
        {



            randonPositions[i].position = vectorPositions[i];


        }



    }
    void ContTime()
    {
        int timeInt;
       
        time += Time.deltaTime*pauseTime;
        timeInt = Mathf.FloorToInt(time);
        timeConter.text = timeInt.ToString();
      
        if (timeInt < 5 && transprent)
        {
            StopPiece();

        }
        if (timeInt == 5&& transprent)
        {
            StartpPiece();
            ShowSprite();
            guideText.enabled = false;

        }
        if(timeInt>=6)
        {
            time = 0;
            min++;
            minTimeCont.text=min.ToString();


        }
        if(min>=1)
        {
            StopPiece();
            GameOver();


        }


    }
    void ShowSprite()
    {
        transprent = false;
        spriteRenderer.color = spriteRenderer.color - new Color(0, 0, 0, 0.7f);
        time = 0;


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

    // Update is called once per frame
    void Update()
    {
     
    }
    public void RandSpriteButton()
    {
        randomSprite = false;
    }
    void ChangePices(int selectPiece)
    {
        for (int i = 0; i <randonPositions.Length ; i++)
        {
            if(selectPiece==1)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces1[i];
            }
            if (selectPiece == 2)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces2[i];
            }
            if (selectPiece == 0)
            {
                randonPositions[i].GetComponent<SpriteRenderer>().sprite = spritePieces3[i];

            }
        }
        startGame = true;
        RandonPiece();



    }
    private IEnumerator RandomSprite()
    {
       while(randomSprite)
        {
            spriteRenderer.sprite = spriteFull[index];
            yield return new WaitForSeconds(0.1f);
            index++;
           

            if (sp1 && index ==0)
            {
                index++;
            }
            else if (sp2&& index == 1)
            {
                index++;
            }
            else if (sp3 && index == 2)
            {
                index++;
            }
            if (index == spriteFull.Length)
            {
                index = 0;
            }

        }
        if(index==0)
        {
            sp1 = true;
        }
        if (index == 1)
        {
            sp2 = true;
        }
        if (index == 2)
        {
            sp3 = true;
        }



       

        ChangePices(index);
           
           
    }
    void GameOver()
    {
        gameOverText.enabled = true;
        pauseTime = 0;
        buttonRestart.SetActive(true);
        buttonSelect.SetActive(false);

    }
    void WinGame()
    {
        winGameText.enabled=true;
        pauseTime = 0;
        buttonRestart.SetActive(true);
        buttonSelect.SetActive(false);
    }
    public void Restart()
    {
        min = 0;
        minTimeCont.text = min.ToString();
        okPieces = 0;
        randomSprite = true;
        transprent = true;
        winGameText.enabled = false;
        gameOverText.enabled = false;
        pauseTime = 1;
        time = 0;
        pauseTime = 1;
        okPieces = 0;
        
        spriteRenderer.color = spriteRenderer.color  +new Color(0, 0, 0, 1);
        StartCoroutine(RandomSprite());
        for (int i = 0; i < randonPositions.Length; i++)
        {
            randonPositions[i].position = originalPosition[i].position;
        }

    }

}
