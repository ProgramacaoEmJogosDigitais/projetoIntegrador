using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMap : MonoBehaviour
{
    
      public GameObject popup;
   
  
   

    public void BackToMap()
    {
        TargetMap.stoped= true;
        popup.gameObject.SetActive(false);

    }
   
}
