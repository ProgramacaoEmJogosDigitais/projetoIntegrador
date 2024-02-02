using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BookSystem : MonoBehaviour
{
    //A cada 625 pontos instancia um livro
    private int nBooks;
    private Progression progressionScript;
    public float metaToTakeBook; //meta para pegar os livros;
    public List<GameObject> prefabBooks;

    private void Start()
    {
        progressionScript = FindObjectOfType<Progression>();
    }

    private void Update()
    {
        if (progressionScript.meta >= metaToTakeBook) //se a meta do player for maior ou igual a meta para a instaciação do livro no game
        {
            metaToTakeBook = +metaToTakeBook;
            int bookIndex = Random.Range(0, prefabBooks.Count);
            GameObject newBook = Instantiate(prefabBooks[bookIndex], transform.position, Quaternion.identity);
            Book bookScript = newBook.GetComponent<Book>();
            //bookScript.SetBookSpeed(currentSpeedInfor); //criar essa funcao************************;
            //spawnedBook.Add(bookScript);
            //newBook.transform.position = new Vector2(transform.position.x, transform.position.y);

        }
    }

}


//int obstacleIndex = Random.Range(0, prefabObstacle.Count);
//GameObject newObstacle = Instantiate(prefabObstacle[obstacleIndex], transform.position, Quaternion.identity);
//Obstacle obstacleScript = newObstacle.GetComponent<Obstacle>();
//obstacleScript.SetObstacleSpeed(currentSpeedInfor);
//spawnedObstacles.Add(obstacleScript);
//newObstacle.transform.position = new Vector2(transform.position.x, transform.position.y);