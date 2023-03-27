using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Obstacle obstacle;
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
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public bool stop = false;

    void Start()
    {
        stop = false;
        currentObstacleSpeed = obstacle.velocity;
        currentParallaxSpeedCloud = cloud.speed;
        currentParallaxSpeedMountains = mountains.speed;
        currentParallaxSpeedFlorest = florest.speed;
        currentParallaxSpeedTree = tree.speed;

    }

    void Update()
    {
        if (!stop)
        {
            currentTime += Time.deltaTime;
            currentDifficultyTime += Time.deltaTime;

            UpdateScore();
            IncreaseDifficulty();
        }
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
    public void Clean()
    {
        stop = true;
        scoreText.text = "Score: 0";
        currentObstacleSpeed = 0;
        currentParallaxSpeedCloud = 0;
        currentParallaxSpeedMountains = 0;
        currentParallaxSpeedFlorest = 0;
        currentParallaxSpeedTree = 0;
    }
}
