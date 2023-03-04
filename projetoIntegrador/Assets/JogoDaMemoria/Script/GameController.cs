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
    [SerializeField]private Image card;
    public Image[,] grid;
    public Sprite[] cardImages;
    public List<Image> cardList;

    void Start()
    {
        // inicializa a matriz de objetos
        grid = new Image[numRows, numCols];

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                // calcula a posição de cada prefab com base no índice da matriz
                Vector3 pos = new Vector3(col - numCols / 2f + 0.5f, row - numRows / 2f + 0.5f, 0) * 1.5f;

                // instancia o prefab na posição calculada e armazena em uma variável local
                Image newCard = Instantiate(card, pos, Quaternion.identity);
                cardList.Add(newCard);
            }
        }
        foreach(Image c in cardList)
        {
            int cardImageIndex = UnityEngine.Random.Range(0, cardImages.Length);
            Sprite randomCardImage = cardImages[cardImageIndex];
            cardImages[cardImageIndex] = null;
            c.sprite = randomCardImage;
        }
    }
    void DisableCanvas(GameObject difficultyLevel)
    {
        difficulty.SetActive(false);
        difficultyLevel.SetActive(true);
    }
}
