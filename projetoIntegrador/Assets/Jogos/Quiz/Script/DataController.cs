using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{

    public RoundData[] AllRounds;

    private int roundIndex;
    private int playerHighScore;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene("Menu");
    }

    
    void Update()
    {
        
    }

    public void SetRoundData (int round)
    {
        roundIndex = round;

    }

    public RoundData GetCurrentData()
    {
        return AllRounds[roundIndex];
    }
}
