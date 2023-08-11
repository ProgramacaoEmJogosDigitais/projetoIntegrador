using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivedAtPoint : MonoBehaviour
{
    public GameObject point;
    public GameObject player;
    public GameObject spritePoint;
    public GameObject backSprite;
    public GameObject popUp;
    
    void FixedUpdate ()
    {
        if (point.transform.position == player.transform.position)//se o carro esta no ponto turistico, aumenta a escala dele
        {
            Debug.Log("entrouuuu");
            spritePoint.transform.localScale = new Vector3(0.4f, 0.4f, 1); 
            backSprite.SetActive(true);
            
        }
        if (point.transform.position != player.transform.position)
        {
            Debug.Log("ELSEEEEEE");
            spritePoint.transform.localScale = new Vector3(0.35f, 0.35f, 1);
            backSprite.SetActive(false);

        }
    }
    
    /*
    public void IntantiatePopUp()
    {
        if (point.transform.position == player.transform.position)//se o carro esta no ponto turistico, aumenta a escala dele
        {
            Debug.Log("entrouuuu");
            //Vector2 vector2 = new Vector2(point.transform.position.x, point.transform.position.y + 2.0f);
            //GameObject ob = Instantiate(popUp, vector2, Quaternion.identity);
            spritePoint.transform.localScale = new Vector3(0.4f, 0.4f, 1);
            backSprite.SetActive(true);

        }
        if (point.transform.position != player.transform.position)
        {
            Debug.Log("ELSEEEEEE");
            spritePoint.transform.localScale = new Vector3(0.35f, 0.35f, 1);
            backSprite.SetActive(false);

        }
    }*/

}
