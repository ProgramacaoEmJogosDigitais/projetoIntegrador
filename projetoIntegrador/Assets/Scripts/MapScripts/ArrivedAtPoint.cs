using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivedAtPoint : MonoBehaviour
{
    public GameObject point;
    public GameObject player;
    public GameObject spritePoint;
    public GameObject backSprite;
  
    void FixedUpdate ()
    {
        if (point.transform.position == player.transform.position)//se o carro esta no ponto turistico, aumenta a escala dele
        {
            spritePoint.transform.localScale = new Vector3(0.4f, 0.4f, 1); 
            backSprite.SetActive(true);
            
        }
        if (point.transform.position != player.transform.position)
        {
            spritePoint.transform.localScale = new Vector3(0.35f, 0.35f, 1);
            backSprite.SetActive(false);

        }
    }
}
