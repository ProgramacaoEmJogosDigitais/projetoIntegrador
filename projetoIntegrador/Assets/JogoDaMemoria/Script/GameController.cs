using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.VersionControl;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public List<Image> cardList;
    public List<Sprite> imageList;
    Dictionary<Sprite, int> spritesAddList = new Dictionary<Sprite, int>();

    public void Cards()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            Sprite randomCardImage;
            int cardImageIndex;
            bool allNull = true;
            do
            {
                cardImageIndex = UnityEngine.Random.Range(0, imageList.Count);
                randomCardImage = imageList[cardImageIndex];

            } while (randomCardImage == null);

            if (allNull != imageList.All(element => element == null))
            {
                Debug.Log("NULLLLLLLLL");
            }

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
}
        /*public Image[,] grid;
        public List<Image> cardList;

        public int numRows;
        public int numCols;

        public Image card;
        public Sprite[] cardImages;
        public Transform cards;

        Dictionary<Sprite, int> spritesAddList = new Dictionary<Sprite, int>();

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
            }
        }
    }
        */
