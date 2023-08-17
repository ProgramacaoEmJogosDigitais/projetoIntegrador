using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReturnToMap : MonoBehaviour
{
    
      public GameObject popup,bNextPage,bBackPage,bGame,bBackGame;
      public int nPages,maxPage;
      public Sprite []pages;
      public GameObject cover,nextP1,nextP2,backMP1,backMP2;
      public SpriteRenderer render;
      


    public void Awake()
    {
        nPages = 0;
    }

    public void Update()
    {
        if(nPages==0)
        {
            render.gameObject.SetActive(false);
            cover.SetActive(true);
            bNextPage.SetActive(true);
            bBackPage.SetActive(false);
            bBackGame.SetActive(true);
            bGame.SetActive(false);
            bBackGame.transform.position = nextP1.transform.position;
            bNextPage.transform.position=backMP1.transform.position;


        }
        else if(nPages>0 && nPages<maxPage)
        {
            render.gameObject.SetActive(true);
            cover.SetActive(false);
            render.sprite = pages[nPages];
            bNextPage.SetActive(true);
            bBackPage.SetActive(true);
            bBackGame.SetActive(true);
            bGame.SetActive(false);
            bBackGame.transform.position = nextP2.transform.position;
            bNextPage.transform.position = backMP2.transform.position;
        }
        else if(nPages==maxPage)
        {
            render.gameObject.SetActive(true);
            cover.SetActive(false);
            bNextPage.SetActive(false);
            bBackPage.SetActive(true);
            bBackGame.SetActive(true);
            bGame.SetActive(true);
            bBackGame.transform.position = nextP2.transform.position;
            bNextPage.transform.position = backMP2.transform.position;
        }
        
    }


    public void BackToMap()
    {
        TargetMap.stoped= true;
        popup.gameObject.SetActive(false);
        nPages = 0;

    }
    public void NextPage()
    {
        if(nPages<=maxPage)
            nPages++;
    }
    public void BackupPage()
    {
        if(nPages>=0)
            nPages--;

    }
   
}
