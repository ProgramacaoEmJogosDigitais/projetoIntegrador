using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandonPositions : MonoBehaviour
{
    public List<Transform> randonPositions;
    private Transform receptacle;
    private int randonIndice;
    // Start is called before the first frame update
    void Start()
    {   
        int i = 0;
        foreach(Transform t in randonPositions)
         {
            receptacle = t;
            randonIndice = Random.Range(0, randonPositions.Count);
            randonPositions[i] = randonPositions[randonIndice];
            i++;

         }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
