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
        gameController.listTransparentPanelSelected.Add(transparentImage);

        Debug.Log("Lista: " + gameController.listImageSelected.Count);


        if (gameController.listImageSelected.Count >= 2)
        {
            Image im1 = gameController.listImageSelected[0];
            Image im2 = gameController.listImageSelected[1];
            Sprite sprite1 = im1.sprite;
            Sprite sprite2 = im2.sprite;

            if (sprite1.name == sprite2.name)
            {
                Debug.Log("Acertou!");
                gameController.listImageSelected.Clear();
                gameController.listTransparentPanelSelected.Clear();
            }
            else
            {
                Debug.Log("Errou!");
                gameController.listImageSelected.Clear();
                Invoke("ResetAlpha", duration);
            }
            Invoke("ResetAlpha", duration);

        }
    }
    public void ResetAlpha()
    {
        GameController gameController = a.GetComponent<GameController>();

        Image transparent1 = gameController.listTransparentPanelSelected[0];
        transparent1.color = new Color(transparentImage.color.r, transparentImage.color.g, transparentImage.color.b, 1);
        gameController.listTransparentPanelSelected.Clear();

        transparentImage.color = new Color(transparentImage.color.r, transparentImage.color.g, transparentImage.color.b, 1);
    }
}