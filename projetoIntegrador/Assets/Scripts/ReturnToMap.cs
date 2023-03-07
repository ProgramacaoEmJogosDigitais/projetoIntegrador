using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMap : MonoBehaviour
{
    
       GameObject popup2;
   
  
    void Awake()
    {
        popup2 = GameObject.FindGameObjectWithTag("Popup");
      
  
    }
   

    public void BackToMap()
    {
        TargetMap.stoped= true;
        popup2.gameObject.SetActive(false);

    }
   
}
