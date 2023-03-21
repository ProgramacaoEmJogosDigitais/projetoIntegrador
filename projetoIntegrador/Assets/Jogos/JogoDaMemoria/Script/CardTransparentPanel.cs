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
    public GameObject objectGameController; //Objeto game controller
    public Image transparentImage;
    public Image image;
    public float duration;

    private void Start()
    {
        button.enabled = false;
        GameController gameController = objectGameController.GetComponent<GameController>();
        gameController.listButton.Clear();
        gameController.listImageSelected.Clear();
        gameController.listTransparentPanelSelected.Clear();
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
        GameController gameController = objectGameController.GetComponent<GameController>();

        if (gameController.s)
        {
            gameController.listImageSelected.Add(image);
            gameController.listTransparentPanelSelected.Add(transparentImage);
            gameController.listButton.Add(button);
            transparentImage.color = new Color(transparentImage.color.r, transparentImage.color.g, transparentImage.color.b, 0);
            button.enabled = false;

            Debug.Log("Lista: " + gameController.listImageSelected.Count);

            if (gameController.listImageSelected.Count == 2)
            {
                gameController.s = false;
                Image im1 = gameController.listImageSelected[0];
                Image im2 = gameController.listImageSelected[1];
                Sprite sprite1 = im1.sprite;
                Sprite sprite2 = im2.sprite;

                if (sprite1.name == sprite2.name)
                {
                    Debug.Log("Acertou!");
                    im1.color = new Color(im1.color.r, im1.color.g, im1.color.b, 0.5f);
                    im2.color = new Color(im2.color.r, im2.color.g, im2.color.b, 0.5f);

                    gameController.listImageSelected.Clear();
                    gameController.listTransparentPanelSelected.Clear();
                    gameController.listButton.Clear();
                    gameController.s = true;
                }
                else
                {
                    Debug.Log("Errou!");
                    Invoke("ResetAlpha", duration);
                }
            }
        }
    }

    public void ResetAlpha()
    {
        GameController gameController = objectGameController.GetComponent<GameController>();
        Image transparent0 = gameController.listTransparentPanelSelected[0];
        transparent0.color = new Color(transparent0.color.r, transparent0.color.g, transparent0.color.b, 1);
        transparentImage.color = new Color(transparentImage.color.r, transparentImage.color.g, transparentImage.color.b, 1);

        Button b0 = gameController.listButton[0];
        Button b1 = gameController.listButton[1];
        b0.enabled = true;
        b1.enabled = true;
        button.enabled = true;
        gameController.listButton.Clear();
        gameController.listImageSelected.Clear();
        gameController.listTransparentPanelSelected.Clear();

        gameController.s = true;
    }
}