using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Attractions : MonoBehaviour
{
    public Canvas canvasDialogue;
    public GameObject attraction0;
    public GameObject attraction1;
    public GameObject attraction2;
    private bool isColliding = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attraction0.gameObject.SetActive(true);
            attraction1.gameObject.SetActive(false);
            isColliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvasDialogue.gameObject.SetActive(false);
            attraction0.gameObject.SetActive(false);
            attraction1.gameObject.SetActive(true);
            isColliding = false;
        }
    }

    private void Update()
    {
        if (isColliding)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || (Input.GetKeyDown(KeyCode.Return)))
            {
                canvasDialogue.gameObject.SetActive(true);
            }
        }
    }

}
