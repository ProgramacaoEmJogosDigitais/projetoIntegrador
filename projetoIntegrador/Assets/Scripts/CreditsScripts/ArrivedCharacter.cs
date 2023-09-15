using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivedCharacter : MonoBehaviour
{
    public Canvas popUpInformations;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            popUpInformations.gameObject.SetActive(true);

            Debug.Log("Entrou");//TODO
            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    Debug.Log("Apertou enter");//TODO
            //    popUpInformations.gameObject.SetActive(true);

            //}
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Saiu"); //TODO
            popUpInformations.gameObject.SetActive(false);


        }
    }
}
