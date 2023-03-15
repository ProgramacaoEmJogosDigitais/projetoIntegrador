using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public GameObject selectDifficulty;
    public GameObject difficulty;
   
    public void SelectDifficulty()
    {
        selectDifficulty.SetActive(false);
        difficulty.SetActive(true);
    }
}
