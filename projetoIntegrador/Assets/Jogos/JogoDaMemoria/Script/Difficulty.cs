using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    GameController gameController;
    public GameObject selectDifficulty;
    public GameObject simpleDifficulty;
    public GameObject normalDifficulty;
    public GameObject hardDifficulty;
   
    public void SelectSimpleDifficulty()
    {
        selectDifficulty.SetActive(false);
        simpleDifficulty.SetActive(true);
    }

    public void SelectNormalDifficulty()
    {
        selectDifficulty.SetActive(false);
        normalDifficulty.SetActive(true);
    }

    public void SelectHardDifficulty()
    {
        selectDifficulty.SetActive(false);
        hardDifficulty.SetActive(true);
    }
}
