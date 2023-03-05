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
    GameController gameController;
    public Image transparentImage;
    public Image image;
    public void OnClick()
    {
        transparentImage.color = new Color(transparentImage.color.r, transparentImage.color.g, transparentImage.color.b, 0);
        gameController.listImageSelected.Add(image);
        gameController.ListImageSelected();
    }
    public void ResetAlpha()
    {
        transparentImage.color = new Color(transparentImage.color.r, transparentImage.color.g, transparentImage.color.b, 1);
    }
}