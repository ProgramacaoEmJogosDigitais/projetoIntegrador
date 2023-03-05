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

    public int numRows = 0;
    public int numCols = 0;
    public int[] imageCount;

    public Image card;
    public Sprite[] cardImages;
    public Transform cards;

    public float duration = 2f;

    Dictionary<Sprite, int> spritesAddList = new Dictionary<Sprite, int>();
    public Image transparentImage;
    public Image imageSelected;
    public void OnClick()
    {
        transparentImage.color = new Color(transparentImage.color.r, transparentImage.color.g, transparentImage.color.b, 0);
        listImageSelected.Add(imageSelected);
        ListImageSelected();
    }
    public void ResetAlpha()
    {
        transparentImage.color = new Color(transparentImage.color.r, transparentImage.color.g, transparentImage.color.b, 1);
    }
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
                Vector3 pos = new Vector3(col - numCols / 2f + 0.5f, row - numRows / 2f + 0.5f, 0) * 65f;
                Image newCard = Instantiate(card, cards);
                newCard.transform.localPosition = pos;
                cardList.Add(newCard);
            }
        }

        for (int i = 0; i < cardList.Count; i++)
        {
            Sprite randomCardImage;
            int cardImageIndex;
            do
            {
                cardImageIndex = UnityEngine.Random.Range(0, cardImages.Length);
                randomCardImage = cardImages[cardImageIndex];

            } while (randomCardImage == null || imageCount[cardImageIndex] >= 2);

            // Marque a imagem como usada
            imageCount[cardImageIndex]++;

            cardList[i].sprite = randomCardImage;
        }
    }
    public void ListImageSelected()
    {
        if (listImageSelected.Count >= 1)
        {
            if (listImageSelected[0].sprite == listImageSelected[1].sprite)
            {
                Debug.Log("Acertou!");
            }
            else
            {
                Invoke("InvokeTransparent", duration);
            }
        }
        Debug.Log("Clique em outra carta!");
    }
    public void InvokeTransparent()
    {
        ResetAlpha();
    }
}


/* for (int i = 0; i < cardList.Count; i++)
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
