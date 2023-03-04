using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // variáveis para configuração do jogo
    public int numRows = 4;
    public int numCols = 4;
    public int maxErrors = 5;
    public float cardShowTime = 2f;
    public float delayBetweenCards = 0.5f;
    public Sprite[] cardFaces;

    // variáveis para referência de objetos na cena
    public GameObject cardPrefab;
    public Transform cardContainer;
    public Text errorText;
    public Text winText;
    public Text gameOverText;

    // variáveis para controle do jogo
    private Card[,] cards;
    private int numPairs;
    private int numMatches;
    private int numErrors;
    private bool isPlaying;

    private void Start()
    {
        // inicializa o jogo
        InitGame();
    }

    private void InitGame()
    {
        // esconde as mensagens de vitória e derrota
        winText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);

        // inicializa as variáveis de controle do jogo
        numPairs = (numRows * numCols) / 2;
        numMatches = 0;
        numErrors = 0;
        isPlaying = true;

        // inicializa a matriz de cartas
        cards = new Card[numRows, numCols];

        // cria as cartas
        CreateCards();

        // embaralha as cartas
        ShuffleCards();

        // esconde as cartas
        HideCards();

        // mostra as cartas por um tempo determinado
        StartCoroutine(ShowCards());
    }

    private void CreateCards()
    {
        // cria as cartas
        int[] pairIDs = GetPairIDs();
        int pairIndex = 0;
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                // cria a carta
                GameObject cardGO = Instantiate(cardPrefab, cardContainer);
                Card card = cardGO.GetComponent<Card>();

                // configura a carta
                card.Face = cardFaces[pairIDs[pairIndex]];
                card.Row = row;
                card.Col = col;

                // adiciona a carta à matriz
                cards[row, col] = card;

                // incrementa o índice do par atual
                pairIndex++;
            }
        }
    }

    private int[] GetPairIDs()
    {
        // gera os IDs dos pares aleatoriamente
        int[] pairIDs = new int[numPairs * 2];
        for (int i = 0; i < numPairs; i++)
        {
            pairIDs[i] = i;
            pairIDs[i + numPairs] = i;
        }

        // embaralha os IDs dos pares
        for (int i = 0; i < pairIDs.Length; i++)
        {
            int temp = pairIDs[i];
            int randomIndex = Random.Range(i, pairIDs.Length);
            pairIDs[i] = pairIDs[randomIndex];
            pairIDs[randomIndex] = temp;
        }

        return pairIDs;
    }

    private void ShuffleCards()
    {
        // embaralha as cartas aleatoriamente
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                Card temp = cards[i, j];
                int randomRow = Random.Range(0

