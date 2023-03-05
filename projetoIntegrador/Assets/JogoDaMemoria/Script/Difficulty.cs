using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public GameController gameController;
    public GameObject selectDifficulty;
    public GameObject simpleDifficulty;
   // public GameObject mediumDifficulty;
   // public GameObject hardDifficulty;

    public void SelectSimpleDifficulty()
    {
        gameController.numRows = 2;
        gameController.numCols = 2;
        selectDifficulty.SetActive(false);
        simpleDifficulty.SetActive(true);
        gameController.Cards();
    }

    public void SelectMediumDifficulty()
    {
        gameController.numRows = 4;
        gameController.numCols = 5;
        selectDifficulty.SetActive(false);
        simpleDifficulty.SetActive(true);
        gameController.Cards();
    }

    public void SelectHardDifficulty()
    {
        gameController.numRows = 4;
        gameController.numCols = 6;
        selectDifficulty.SetActive(false);
        simpleDifficulty.SetActive(true);
        gameController.Cards();
    }

}
