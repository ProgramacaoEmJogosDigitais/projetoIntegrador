using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Image background;
    public float speed;

    private float width = 1920;
    public bool aa = true;
    private void Update()
    {
        if (aa)
        {
            MoveBackground();
        }
    }
    private void MoveBackground()
    {
        // Movimenta��o da imagem
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        // Se a imagem j� saiu da tela, troca de posi��o pro lado contr�rio
        if (transform.localPosition.x <= -width)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + width * 2, 0, 0);
        }
    }
}
