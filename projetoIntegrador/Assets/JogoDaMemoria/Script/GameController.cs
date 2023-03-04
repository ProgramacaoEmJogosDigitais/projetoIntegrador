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
    [SerializeField] private GameObject difficulty;

    public int numRows;
    public int numCols;

    public Image card;
    public Image[,] grid;
    public Sprite[] cardImages;
    public List<Image> cardList;
    Dictionary<Sprite, int> spritesAddList = new Dictionary<Sprite, int>();

    public Transform cards;
    void Start()
    {
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

            if (spritesAddList.ContainsKey(randomCardImage) && spritesAddList[randomCardImage] >= 2)
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
    void DisableCanvas(GameObject difficultyLevel)
    {
        difficulty.SetActive(false);
        difficultyLevel.SetActive(true);
    }
}
