using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    public Transform[] characterPositions; // Posições dos personagens na grade
    public Sprite[] photos;
    public Image photoGame;
    public TextMeshPro description;
    private int rows = 3; // Número de linhas na grade
    private int cols = 4; // Número de colunas na grade
    private int currentIndex = 0;
    private bool canMove = true;

    void Start()
    {
        // Define a posição inicial do seletor para o primeiro personagem
        transform.position = characterPositions[currentIndex].position;
    }

    void Update()
    {
        if (!canMove) return;
        
        SelectCharacter();

        float horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalInput) > 0.5f)
        {
            MoveSelector((int)Mathf.Sign(horizontalInput), 0);
        }
    }

    void MoveSelector(int horizontalDirection, int verticalDirection)
    {
        int nextIndex = currentIndex + horizontalDirection + verticalDirection * cols;
        nextIndex = Mathf.Clamp(nextIndex, 0, characterPositions.Length - 1);
        StartCoroutine(MoveToPosition(characterPositions[nextIndex].position));
        currentIndex = nextIndex;
    }

    void SelectCharacter()
    {
        string characterName = characterPositions[currentIndex].name;
        Debug.Log("Personagem selecionado: " + characterName);
        switch (characterName)
        {
            case "Ana":
                photoGame.GetComponent<Image>().sprite = photos[0];
                description.text = "Ana Graziela Monteiro dos Santos - Disse se é Gaiatooooo 545 vezes e ficou emburrada quase todas as aulas.";
                break;
            case "Augusto":
                photoGame.GetComponent<Image>().sprite = photos[1];
                description.text = "Augusto Anguita Arrizabalaga - Não tem o que dizer, não veio nas aulas. " +
                    "Reclamou de tudo, as poucas aulas que veio, disse que não conseguia mas foi la e fez";
                break;
            case "Felipe":
                photoGame.GetComponent<Image>().sprite = photos[2];
                description.text = "Filipe de Lima - Nosso bebezinho, organizou todo o Hacknplan com maestria. Ainda deve ao professor uma luta de boxe";
                break;
            case "Guilherme":
                photoGame.GetComponent<Image>().sprite = photos[3];
                description.text = "Guilherme Barros de Deus - Nosso atleta, artista de mão cheia, não presta atenção na aula mas é bom garoto.";
                break;
            case "Josias":
                photoGame.GetComponent<Image>().sprite = photos[4];
                description.text = "Josias Matheus Mendes, Exelente artista, aparece pouco nas auls, mas é focado nos desenhos.";
                break;
            case "Juliano":
                photoGame.GetComponent<Image>().sprite = photos[5];
                description.text = "Juliano Alves Monteiro - Organizou os documentos e liderou a equipe, mesmo sem ser o lider, mas fez um bom trabalho.";
                break;
            case "Kaike":
                photoGame.GetComponent<Image>().sprite = photos[6];
                description.text = "Kaiki Hiraga Higa - Especialista em desenhar mapas.";
                break;
            case "Leon":
                photoGame.GetComponent<Image>().sprite = photos[7];
                description.text = "Leon Moraes Cruz - Profissional no jogo de luta, menos no MK3U, achou nossos sons, anda faltando demais, garoto do bem";
                break;
            case "Melly":
                photoGame.GetComponent<Image>().sprite = photos[8];
                description.text = "Melly Sabrina Araujo Miranda - Ex-caçadora de dinossauro no acre, programadora eximia, especialista em fazer as tarefas do Augusto.";
                break;
            case "Tati":
                photoGame.GetComponent<Image>().sprite = photos[9];
                description.text = "Tatiana Oshiro Kobayashi - Fez a gestão do projeto, escreveu o GDD, ajudou os colegas com o git, não falta nas aulas." +
                    " Mas o mouse é esquisito.";
                break;
            case "Mauricio":
                photoGame.GetComponent<Image>().sprite = photos[10];
                description.text = "Mauricio de Souza Estevam - Ao longo do projeto, pude partilhar saberes com cada aluno; entretanto, " +
                    "a verdadeira riqueza foi testemunhar a evolução notável de cada um de vocês.";
                break;
        }

    }

    System.Collections.IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        canMove = false; 
        float moveSpeed = 5f;
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        canMove = true; 
    }
}
