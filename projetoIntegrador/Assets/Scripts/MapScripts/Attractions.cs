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
    private Transform transf;

    private void Start()
    {
        transf.localScale = new Vector3(attraction.transform.localScale.x + 1f, attraction.transform.localScale.y + 1f, attraction.transform.localScale.z);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvasDialogue.gameObject.SetActive(false);
            attraction.transform.localScale = new Vector3(attraction.transform.localScale.x - 1f, attraction.transform.localScale.y - 1f, attraction.transform.localScale.z);
            isColliding = false;
        }
    }

    private void Update()
    {
        if (isColliding)
        {
            attraction.transform.localScale = transf.localScale;

            if (Input.GetKeyDown(KeyCode.KeypadEnter) || (Input.GetKeyDown(KeyCode.Return)))
            {
                canvasDialogue.gameObject.SetActive(true);
            }
        }
    }

}
