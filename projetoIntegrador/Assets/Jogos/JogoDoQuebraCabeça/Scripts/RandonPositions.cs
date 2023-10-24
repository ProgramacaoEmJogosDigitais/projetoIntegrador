using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandonPositions : MonoBehaviour
{
    public Transform []randonPositions;
    public Vector3[] vectorPositions; 
     private Vector3 receptacle;
    public  int randonIndice,len;
    public List<int> randonIndiceList;
    int index;
    
    public bool repet;
    // Start is called before the first frame update
    void Start()
    {
       //receptacle = new Transform();
        len = randonPositions.Length - 1;
        repet = false;
        receptacle = new Vector3();
        for (int j = 0; j < 24; j++)
        {
            vectorPositions[j] = randonPositions[randonIndiceList[j]].position;
        }
        
       
      
        Debug.Log("1");
        for (int i = 0; i < randonPositions.Length; i++)
        {
           


            randonPositions[i].position = vectorPositions[i];
          //  randonPositions[randonIndiceList[i]].position = receptacle;

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
    void RandonList()
    {
       
       

        for (int i = 0; i < 25; i++)
        {
            index = Random.Range(0, 25);
            if (randonIndiceList.Count > 0)
            {
                randonIndiceList.Add(index);
            }
            else
            {
                do
                {
                    index = Random.Range(0, 25);

                } while(NoRepeat(index));
                index = Random.Range(0, 25);

            }
                

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
