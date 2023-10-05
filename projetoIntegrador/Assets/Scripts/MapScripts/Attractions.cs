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
    public GameObject attraction;
    private bool isColliding = false;

    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attraction.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            isColliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvasDialogue.gameObject.SetActive(false);
            attraction.transform.localScale = new Vector3(1, 1, 1);
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
