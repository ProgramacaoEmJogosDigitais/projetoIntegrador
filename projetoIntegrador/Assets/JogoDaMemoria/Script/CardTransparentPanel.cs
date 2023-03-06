using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CardTransparentPanel : MonoBehaviour
{
    public GameObject a;
    public Image transparentImage;
    public Image image;
    public float duration = 2f;

    public void OnClick()
    {
        GameController gameController = a.GetComponent<GameController>();
        transparentImage.color = new Color(transparentImage.color.r, transparentImage.color.g, transparentImage.color.b, 0);
        gameController.listImageSelected.Add(image);
        Debug.Log("Lista: "+ gameController.listImageSelected.Count);

        if (gameController.listImageSelected.Count >= 2)
        {
            if (gameController.listImageSelected[0].sprite.name == gameController.listImageSelected[1].sprite.name)
            {
                Debug.Log("Acertou!");
                gameController.listImageSelected = null;
            }
            else
            {
                Invoke("ResetAlpha", duration);
            }
        }
        else
        {
            ResetAlpha();
        }
    }
    public void ResetAlpha()
    {
        transparentImage.color = new Color(transparentImage.color.r, transparentImage.color.g, transparentImage.color.b, 1);
    }
}