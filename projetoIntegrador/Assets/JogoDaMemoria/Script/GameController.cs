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

    /*public List<Image> cardList;
    public List<Sprite> imageList;
    Dictionary<Sprite, int> spritesAddList = new Dictionary<Sprite, int>();

    public void Cards()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            Sprite randomCardImage;
            int cardImageIndex;
            do
            {
                cardImageIndex = UnityEngine.Random.Range(0, imageList.Count);
                randomCardImage = imageList[cardImageIndex];

                if (randomCardImage == null)
                {
                    Debug.Log("NULLLLLLLLL");
                }
            } while (randomCardImage == null);


            if (spritesAddList.ContainsKey(randomCardImage) && spritesAddList[randomCardImage] >= 1)
            {
                imageList[cardImageIndex] = null;
            }
            else
            {
                if (spritesAddList.ContainsKey(randomCardImage))
                {
                    spritesAddList[randomCardImage]++;
                }
                else
                {
                    spritesAddList.Add(randomCardImage, 1);
                }
            }
            cardList[i].sprite = randomCardImage;
        }
    }
}*/
    public Image[,] grid;
    public List<Image> cardList;
    public List<Image> listImageSelected = null;
    public List<Image> listTransparentPanelSelected = null;
    public List<Button> listButton = null;

    public float space;
    public int numRows = 0;
    public int numCols = 0;
    public int[] imageCount;

    public Image card;
    public Sprite[] cardImages;
    public Transform cards;

    CardTransparentPanel cardTransparentPanel;

    Dictionary<Sprite, int> spritesAddList = new Dictionary<Sprite, int>();

    private void Start()
    {
        imageCount = new int[cardImages.Length];
    }
    public void Cards()
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

        /*for (int i = 0; i < cardList.Count; i++)
        {
            Sprite randomCardImage;
            int cardImageIndex;
            bool allNull = true;
            do
            {
                cardImageIndex = UnityEngine.Random.Range(0, cardImages.Length);
                randomCardImage = cardImages[cardImageIndex];

            } while (randomCardImage == null);

            if (allNull != cardImages.All(element => element == null))
            {
                Debug.Log("NULLLLLLLLL");
            }

            if (spritesAddList.ContainsKey(randomCardImage) && spritesAddList[randomCardImage] >= 1)
            {
                cardImages[cardImageIndex] = null;
            }
            else
            {
                if (spritesAddList.ContainsKey(randomCardImage))
                {
                    spritesAddList[randomCardImage]++;
                }
                else
                {
                    spritesAddList.Add(randomCardImage, 1);
                }
            }
            cardList[i].sprite = randomCardImage;
        }*/
    }
}
