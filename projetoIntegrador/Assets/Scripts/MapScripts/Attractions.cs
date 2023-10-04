using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class Attractions : MonoBehaviour
{
    public Canvas canvasDialogue;
    public SpriteRenderer backSprite;
    private bool isColliding = false;

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
            backSprite.gameObject.SetActive(false);
            isColliding = false;
        }
    }

    private void Update()
    {
        if (isColliding)
        {
            backSprite.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || (Input.GetKeyDown(KeyCode.Return)))
            {
                canvasDialogue.gameObject.SetActive(true);
            }
        }
    }

}
