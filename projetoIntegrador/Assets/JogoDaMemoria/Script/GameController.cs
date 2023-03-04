using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
        int ca = cardList.Count;
        Debug.Log("quantidade de cartas: " + ca);
        for (int i = 0; i < cardList.Count; i++)
        {
            int cardImageIndex = UnityEngine.Random.Range(0, cardImages.Length);
            Sprite randomCardImage = cardImages[cardImageIndex];
            cardImages[cardImageIndex] = null;
            cardList[i].sprite = randomCardImage;
            Debug.Log(cardList[i]);
        }
    }
    void DisableCanvas(GameObject difficultyLevel)
    {
        difficulty.SetActive(false);
        difficultyLevel.SetActive(true);
    }
}
