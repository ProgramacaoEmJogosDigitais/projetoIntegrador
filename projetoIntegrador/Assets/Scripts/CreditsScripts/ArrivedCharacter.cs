using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrivedCharacter : MonoBehaviour
{
    public Canvas popUpInformations;
    private bool collisionPlayer = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (collisionPlayer)
        {
            Debug.Log("Entrou");//TODO
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Debug.Log("APErtoru");//TODO
                popUpInformations.gameObject.SetActive(true);
            }
        } 
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Saiu"); //TODO
            collisionPlayer = false;
            popUpInformations.gameObject.SetActive(false);


        }
    }
}
