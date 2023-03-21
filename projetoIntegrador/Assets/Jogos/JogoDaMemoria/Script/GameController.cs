using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.VersionControl;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.WSA;

public class GameController : MonoBehaviour
{
    public Image[,] grid; //grade
    public List<Image> cardList; // lista de cartas
    public List<Image> listImageSelected = null; //lista de imagens selecionadas
    public List<Image> listTransparentPanelSelected = null; //lista de paineis transparentes selecionados que esconde as imagens
    public List<Button> listButton = null; //lista de butões
    public bool s = true;


    public float space; //espaço entre as cartas
    private int numRows = 0; //numero de linhas
    private int numCols = 0; //numero de colunas
    public int[] imageCount; //vetor de imagens

    public Image card; //Imagem da carta
    public Sprite[] cardImages; //vetor das imagens das cartas
    public Transform cards; //local(canvas) onde as cartas vão ser instanciadas

    CardTransparentPanel cardTransparentPanel;

    Dictionary<Sprite, int> spritesAddList = new Dictionary<Sprite, int>();

    private void Start()
    {
        imageCount = new int[cardImages.Length];
        cardList.Clear();
    }
    public void Cards(int numRows, int numCols)
    {
        grid = new Image[numRows, numCols];

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                Vector3 pos = new Vector3(col - numCols / 2f + 0.5f, row - numRows / 2f + 0.5f, 0) * space;
                Image newCard = Instantiate(card, cards);
                newCard.transform.localPosition = pos;
                cardList.Add(newCard);
            }
        }
         int im = cardImages.Length;
         int ca = cardList.Count;
         if (im > ca / 2)
         {
             Debug.Log("menor i: " + im + "c" + ca);
             int a = ca / 2;
             a = im - a;
             for (int j = 0; j < a; j++)
             {
                 cardImages[j] = null;
             }
         }
        // Criar uma lista para armazenar os índices das imagens disponíveis
        List<int> availableImageIndices = new List<int>();
        for (int i = 0; i < cardImages.Length; i++)
        {
            if (cardImages[i] != null)
            {
                availableImageIndices.Add(i);
            }
        }

        // Percorrer as cartas e atribuir imagens aleatoriamente
        foreach (var card in cardList)
        {
            // Selecionar aleatoriamente um índice da lista de imagens disponíveis
            int randomIndex = UnityEngine.Random.Range(0, availableImageIndices.Count);
            int imageIndex = availableImageIndices[randomIndex];

            // Atribuir a imagem correspondente à carta atual
            card.sprite = cardImages[imageIndex];

            // Verificar se a imagem selecionada já foi usada várias vezes
            if (spritesAddList.ContainsKey(card.sprite) && spritesAddList[card.sprite] >= 1)
            {
                // Remover o índice da lista de imagens disponíveis
                availableImageIndices.RemoveAt(randomIndex);
            }
            else
            {
                // Adicionar a imagem ao dicionário de contagem de ocorrências
                if (spritesAddList.ContainsKey(card.sprite))
                {
                    spritesAddList[card.sprite]++;
                }
                else
                {
                    spritesAddList.Add(card.sprite, 1);
                }
            }
        }
    }
    public void Simple()
    {
        numRows = 2;
        numCols = 5;
        Cards(numRows, numCols);
    }    
    public void Normal()
    {
        numRows = 4;
        numCols = 5;
        Cards(numRows, numCols);
    }   
    public void Hard()
    {
        numRows = 5;
        numCols = 6;
        Cards(numRows, numCols);
    }
}
