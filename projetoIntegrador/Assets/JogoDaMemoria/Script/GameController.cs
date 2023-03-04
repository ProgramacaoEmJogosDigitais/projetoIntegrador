using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject difficulty;

    public int numRows;
    public int numCols;
    public GameObject card;
    public GameObject[,] grid;

    void Start()
    {
        // inicializa a matriz de objetos
        grid = new GameObject[numRows, numCols];

        // instancia o objeto em cada posição da matriz
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                grid[row, col] = Instantiate(card, new Vector3(row, col, 0), Quaternion.identity);
            }
        }
    }

    public void DisableCanvas(GameObject difficultyLevel)
    {
        difficulty.SetActive(false);
        difficultyLevel.SetActive(true);
    }
}
