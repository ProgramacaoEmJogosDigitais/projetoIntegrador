using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Medium : MonoBehaviour
{
    public Image[,] grid;
    public List<Image> cardList;

    public int numRows = 0;
    public int numCols = 0;

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
