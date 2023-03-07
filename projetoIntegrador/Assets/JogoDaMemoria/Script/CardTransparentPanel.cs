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
    public Button button;
    public GameObject a;
    public Image transparentImage;
    public Image image;
    public float duration;

    private void Start()
    {
        button.enabled = false;
        GameController gameController = a.GetComponent<GameController>();
        gameController.listImageSelected.Clear();
        gameController.listTransparentPanelSelected.Clear();
        gameController.listButton.Clear();
        transparentImage.color = new Color(transparentImage.color.r, transparentImage.color.g, transparentImage.color.b, 0);
        Invoke("Cards", duration);
    }
    public void Cards()
    {
        transparentImage.color = new Color(transparentImage.color.r, transparentImage.color.g, transparentImage.color.b, 1);
        button.enabled = true;
    }
    public void OnClick()
    {

        GameController gameController = a.GetComponent<GameController>();

        transparentImage.color = new Color(transparentImage.color.r, transparentImage.color.g, transparentImage.color.b, 0);
        gameController.listImageSelected.Add(image);
        gameController.listTransparentPanelSelected.Add(transparentImage);
        gameController.listButton.Add(button);

        Debug.Log("Lista: " + gameController.listImageSelected.Count);

        if (gameController.listImageSelected.Count == 2)
        {
            Image im1 = gameController.listImageSelected[0];
            Image im2 = gameController.listImageSelected[1];
            Sprite sprite1 = im1.sprite;
            Sprite sprite2 = im2.sprite;

            if (sprite1.name == sprite2.name)
            {
                Button b1 = gameController.listButton[0];
                Button b2 = gameController.listButton[1];
                b1.enabled = false;
                b2.enabled = false;
                Debug.Log("Acertou!");
                im1.color = new Color(im1.color.r, im1.color.g, im1.color.b, 0.5f);
                im2.color = new Color(im2.color.r, im2.color.g, im2.color.b, 0.5f);
                gameController.listImageSelected.Clear();
                gameController.listTransparentPanelSelected.Clear();
                gameController.listButton.Clear();
            }
            else
            {
                Debug.Log("Errou!");
                gameController.listImageSelected.Clear();
                gameController.listButton.Clear();
                Invoke("ResetAlpha", duration);
            }
        }
    }
    public void ResetAlpha()
    {
        GameController gameController = a.GetComponent<GameController>();

        Image transparent1 = gameController.listTransparentPanelSelected[0];
        transparent1.color = new Color(transparent1.color.r, transparent1.color.g, transparent1.color.b, 1);
        transparentImage.color = new Color(transparentImage.color.r, transparentImage.color.g, transparentImage.color.b, 1);
        gameController.listTransparentPanelSelected.Clear();
    }
}