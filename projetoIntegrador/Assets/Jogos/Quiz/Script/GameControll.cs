using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControll : MonoBehaviour
{
    public Text textAnswer;
    public Text textPoints;
    public Text highScoreText;

    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject panelAnswers;
    public GameObject panelEndRound;

    private DataController dataController;
    private RoundData roundActual;
    private QuestionData[] questionPool;

    private bool roundActive;
    private int questionIndex;
    private int playerScore;

    List<int> usedValues = new List<int>();

    private List<GameObject> answerButtonGameObjects = new List<GameObject>();


    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        roundActual = dataController.GetCurrentData();
        questionPool = roundActual.perguntas;
        
        playerScore = 0;
        questionIndex = 1;
        roundActive = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowQuestion()
    {
        RemoveAnswersButtons();
        int random = Random.Range(0, questionPool.Length);

        while (usedValues.Contains(random))
        {
            random = Random.Range(0, questionPool.Length);
        }

        QuestionData questionData = questionPool[random];
        usedValues.Add(random);
        textAnswer.text = questionData.textQuestion;

        for(int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();

            answerButtonGameObjects.Add(answerButtonGameObject);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }
    }

    private void RemoveAnswersButtons()
    {
        while(answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += roundActual.pontosPorAcertos;
            textPoints.text = "Score: " + playerScore.ToString();
        }

        if(questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        }
        else
        {
            EndRound();
        }
    }

    public void EndRound()
    {
        roundActive = false;

        panelAnswers.SetActive(false);
        panelEndRound.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
