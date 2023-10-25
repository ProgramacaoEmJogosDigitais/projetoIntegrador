using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandonPositions : MonoBehaviour
{
    public Transform []randonPositions;
    public Vector3[] vectorPositions;
    public TextMeshProUGUI guideText,timeConter;

    
    public  int randonIndice,len;
    public List<int> randonIndiceList;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spritePieces1,spritePieces2,spritePieces3, spriteFull;
  
    int index;
    public float time;
    bool startGame,randomSprite,transprent;
  
    
    public bool repet;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
       if(startGame)
        {
            ContTime();
        }
       
    }
    void Start()
    {
        randomSprite = true;
        transprent = true;




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
        time += Time.deltaTime;
        timeInt = Mathf.FloorToInt(time);
        timeConter.text = timeInt.ToString();
        if (timeInt == 5&& transprent)
        {
            ShowSprite();
        }


    }
    void ShowSprite()
    {
        transprent = false;
        spriteRenderer.color = spriteRenderer.color - new Color(0, 0, 0, 0.7f);
        time = 0;


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
            if(index == spriteFull.Length)
            {
                index = 0;
            }

        }
       ChangePices(index);
           
           
    }

}
