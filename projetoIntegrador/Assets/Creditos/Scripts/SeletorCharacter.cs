using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeletorCharacter : MonoBehaviour
{
    public Renderer[] formasHud; //refer�ncias para altera��o de cor
    public GameObject[] formas; //prefabs
    public int tipo = 0; //ind�ce da forma selecionado

    public GameObject[,] pecas = new GameObject[13, 7];  //tabuleiro  

    public void avancarForma()
    {

        tipo = Mathf.Clamp(++tipo, 0, 4);
        
    }
    public void recuarForma()
    {

        tipo = Mathf.Clamp(--tipo, 0, 4);

    }
}
