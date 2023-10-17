using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandonPositions : MonoBehaviour
{
    public Transform []randonPositions;
    public Transform receptacle;
    public  int randonIndice,len;
    public List<int> randonIndiceList;
    
    public bool repet;
    // Start is called before the first frame update
    void Start()
    {
        len = randonPositions.Length - 1;
        repet = false;
        randonIndiceList = new List<int>(); 
      
        Debug.Log("1");
        for (int i = 0; i < randonPositions.Length; i++)
        {
            receptacle.position = randonPositions[Random.Range(0,randonPositions.Length)].position;
            Debug.Log(i +" "+" "+ (len-i));



            randonPositions[i].position = randonPositions[len-i].position;

            randonPositions[len - i].position = receptacle.position;


        }
       


   
           

        
        
    }
   public  bool NoRepeat(int index)
    {
        foreach(int t in randonIndiceList)
        {
           if(index==t)
            {
                repet= true;
            }

        }
        if(!repet)
        {
            
            return true ;
        }
        else
        {
            return false;

        }
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
