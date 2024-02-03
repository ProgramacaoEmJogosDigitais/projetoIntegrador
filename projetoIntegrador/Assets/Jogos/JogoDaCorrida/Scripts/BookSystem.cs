using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BookSystem : MonoBehaviour
{
    //A cada 625 pontos instancia um livro
    public float metaTakeBook;
    public float increaseMetaTakeBook;
    public List<GameObject> prefabBook; //lista de livros
    private MovimentPlayer movimentPlayerScript;
    private Book bookScript;
    public float currentSpeedInfor;
    public int nBooks;
    private int countBook;
    //private List<Book> spawnedBooks { get; set; } = new List<Book>(); // Lista de livros instanciados

    private void Start()
    {
        movimentPlayerScript = FindObjectOfType<MovimentPlayer>();
        bookScript = FindObjectOfType<Book>();
        countBook = 0;
    }

    void Update() //verifica se atingiu a meta de pegar o livro para instancia-lo
    {
        if (movimentPlayerScript.distance >= metaTakeBook)
        {
            GameObject newBook = Instantiate(prefabBook[countBook], transform.position, Quaternion.identity);
            Book bookScript = newBook.GetComponent<Book>();
            bookScript.SetBookSpeed(currentSpeedInfor);
            //spawnedBooks.Add(bookScript);
            newBook.transform.position = new Vector2(transform.position.x, transform.position.y);
            metaTakeBook = metaTakeBook + increaseMetaTakeBook;
            countBook++;
            Debug.Log(metaTakeBook);
        }
        if(countBook > 4)
        {

        }
        //if (bookScript.collectedBook)
        //{
        //    //preciso remover da lista o livro coletado
        //}
    }
}