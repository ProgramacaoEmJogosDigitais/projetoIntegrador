using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerJC : MonoBehaviour
{
    public GameObject[] prefabFishs;
    public static int lostObjectsForGameOver = 3;
    public GameObject gameOverObject;
    public TextMeshProUGUI score_txt;
    public TextMeshProUGUI missScore_txt;
    public TextMeshProUGUI waveInfoText;
    public TextMeshProUGUI score;

    public int maxEnemiesPerWave = 10;
    public float initialSpawnDelay = 3f;
    public float spawnInterval = 3f;
    public float spawnRateIncrease = 0.2f;

    private int currentWave = 1;
    private int enemiesSpawned = 0;
    private float nextSpawnTime = 0f;

    public Canvas scrollViewInstructions;


    void Start()
    {
        gameOverObject.SetActive(false);
        PlayerColeta.missingObjects = 0;
        StartCoroutine(SpawnObjects());
        FishsFalling.points = 0;

        // Verifica se as instruções já foram exibidas antes de iniciá-las.
        /*if (!PlayerPrefs.HasKey("InstructionsShown") || PlayerPrefs.GetInt("InstructionsShown") == 0)
        {
            StartCoroutine(SpawnInstructions());
        }*/

    }

    public void Update()
    {
        Score();

        GameOver();
        // Check if the game over condition is met
        if (PlayerColeta.missingObjects >= lostObjectsForGameOver)
        {
            // Disable fish and trash spawning
            nextSpawnTime = float.MaxValue;
        }
    }

    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(initialSpawnDelay);

        while (true)
        {
            if (Time.time >= nextSpawnTime && enemiesSpawned < maxEnemiesPerWave)
            {
                float x = Random.Range(-8f, 8f);
                float y = 7f;
                Vector2 spawnPosition = new Vector2(x, y);
                Instantiate(prefabFishs[Random.Range(0, prefabFishs.Length)], spawnPosition, Quaternion.identity);
                enemiesSpawned++;
                nextSpawnTime = Time.time + spawnInterval;
            }
            if (enemiesSpawned >= maxEnemiesPerWave)
            {
                currentWave++;
                maxEnemiesPerWave += Mathf.RoundToInt(maxEnemiesPerWave * spawnRateIncrease);
                enemiesSpawned = 0;
                nextSpawnTime = Time.time + initialSpawnDelay;
                spawnInterval -= 0.1f;
            }
            waveInfoText.text = string.Format("Wave: {0}\nEnemies Spawned: {1}/{2}\nSpawn Interval: {3:F1}s", currentWave, enemiesSpawned, maxEnemiesPerWave, spawnInterval);

            yield return null;
        }
    }

    public void Score()
    {
        // Texts that appear in the game
        missScore_txt.text = PlayerColeta.missingObjects.ToString();
        score_txt.text = "X" + FishsFalling.points.ToString();
    }

    public void GameOver()
    {
        int resetScore = 0;
        if (PlayerColeta.missingObjects >= 3)
        {
            score.text = score_txt.text;
            gameOverObject.SetActive(true);
            score_txt.text = resetScore.ToString();
        }
    }

    /*public IEnumerator SpawnInstructions()
    {
        yield return new WaitForSeconds(1);
        scrollViewInstructions.gameObject.SetActive(true);
        PlayerPrefs.SetInt("InstructionsShown", 1); // Instruções exibidas.
    }

    public void GoGame()
    {
        scrollViewInstructions.gameObject.SetActive(false);
    }*/
}