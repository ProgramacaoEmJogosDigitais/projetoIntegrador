using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandonPositions : MonoBehaviour
{
    public Transform []randonPositions;
    public Vector3[] vectorPositions; 

    
    public  int randonIndice,len;
    public List<int> randonIndiceList;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spritePiece1,spritePices2,spritePices3, spriteFull;
  
    int index;
    float time;
    bool startGame,randomSprite;
  
    
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
        time += Time.deltaTime;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RandSpriteButton()
    {
        randomSprite = false;
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
           
           
    }

}
