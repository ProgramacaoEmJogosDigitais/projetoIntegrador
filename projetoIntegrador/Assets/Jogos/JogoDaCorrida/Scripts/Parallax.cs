using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Image background;
    public float speed;

    private float width = 1920;


    // Update is called once per frame
    void Update()
    {
        MoveBackground();
    }

    private void MoveBackground()
    {
        // Movimentação da imagem
        transform.Translate(- speed * Time.deltaTime, 0, 0);

        // Se a imagem já saiu da tela, troca de posição pro lado contrário
        if (transform.localPosition.x <= -width)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + width * 2, 0, 0);
        }
    }
}
