using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject obstacle;
    public Parallax cloud;
    public Parallax cloud1;
    public Parallax mountains;
    public Parallax mountains1;
    public Parallax florest;
    public Parallax florest1;
    public Parallax tree;
    public Parallax tree1;

    public float difficultyIncreaseTime; // tempo para aumentar a dificuldade em segundos
    public float obstacleSpeedIncrease; // quanto a velocidade do obstáculo aumenta a cada aumento de dificuldade
    public float parallaxSpeedIncrease; // quanto a velocidade do parallax aumenta a cada aumento de dificuldade
    public float currentTime;
    private float currentDifficultyTime;
    public float currentObstacleSpeed;
    public float currentParallaxSpeedCloud;
    public float currentParallaxSpeedMountains;
    public float currentParallaxSpeedFlorest;
    public float currentParallaxSpeedTree;
    private int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        currentObstacleSpeed = obstacle.GetComponent<Obstacle>().velocity;
        currentParallaxSpeedCloud = cloud.speed;
        currentParallaxSpeedMountains = mountains.speed;
        currentParallaxSpeedFlorest= florest.speed;
        currentParallaxSpeedTree= tree.speed;

    }

    void Update()
    {
        currentTime += Time.deltaTime;
        currentDifficultyTime += Time.deltaTime;

        UpdateScore();
        IncreaseDifficulty();
    }

    void UpdateScore()
    {
        score = Mathf.RoundToInt(currentTime);
        scoreText.text = "Score: " + score.ToString();
    }

    void IncreaseDifficulty()
    {
        if (currentDifficultyTime >= difficultyIncreaseTime)
        {
            currentDifficultyTime = 0f;
            currentObstacleSpeed += obstacleSpeedIncrease;
            currentParallaxSpeedCloud += parallaxSpeedIncrease;
            currentParallaxSpeedMountains += parallaxSpeedIncrease;
            currentParallaxSpeedFlorest += parallaxSpeedIncrease;
            currentParallaxSpeedTree += parallaxSpeedIncrease;

            obstacle.GetComponent<Obstacle>().velocity = currentObstacleSpeed;
            cloud.GetComponent<Parallax>().speed = currentParallaxSpeedCloud;
            cloud1.GetComponent<Parallax>().speed = currentParallaxSpeedCloud;
            mountains.GetComponent<Parallax>().speed = currentParallaxSpeedMountains;
            mountains1.GetComponent<Parallax>().speed = currentParallaxSpeedMountains;
            florest.GetComponent<Parallax>().speed = currentParallaxSpeedFlorest;
            florest1.GetComponent<Parallax>().speed = currentParallaxSpeedFlorest;
            tree.GetComponent<Parallax>().speed = currentParallaxSpeedTree;
            tree1.GetComponent<Parallax>().speed = currentParallaxSpeedTree;
        }
    }
}
