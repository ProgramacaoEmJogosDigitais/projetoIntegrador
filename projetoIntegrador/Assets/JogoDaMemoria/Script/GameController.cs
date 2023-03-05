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
    private int numRows;
    private int numCols;

    private Image[,] grid;
    private List<Image> cardList;

    [SerializeField] private GameObject difficulty;
    [SerializeField] private Image card;
    [SerializeField] private Sprite[] cardImages;
    [SerializeField] private Transform cards;

    Dictionary<Sprite, int> spritesAddList = new Dictionary<Sprite, int>();

    void Cards(int size)
    {
        if(size == 1)
        {
            numRows = 2;
            numCols = 5;
        }
        else if(size == 2)
        {
            numRows = 4;
            numCols = 5;
        }
        else if(size == 3)
        {
            numRows = 5;
            numCols = 6;
        }
        else
        {
            Debug.Log("Valor inválido!");
        }
        // inicializa a matriz de objetos
        grid = new Image[numRows, numCols];

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                // calcula a posição de cada prefab com base no índice da matriz
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

            } while (randomCardImage == null && allNull != cardImages.All(element => element == null));

            if(randomCardImage == null && allNull != cardImages.All(element => element == null)){
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
    public void DisableCanvas(GameObject difficultyLevel)
    {
        difficulty.SetActive(false);
        difficultyLevel.SetActive(true);
    }
    public void Size(int size)
    {
        Cards(size);
    }
}
