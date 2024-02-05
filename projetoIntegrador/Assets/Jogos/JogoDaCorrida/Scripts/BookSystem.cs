using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BookSystem : MonoBehaviour
{
    //A cada 300 pontos instancia um livro
    public float metaTakeBook;
    public float increaseMetaTakeBook;
    public List<GameObject> prefabBook; //lista de livros
    public List<GameObject> livrosInstanciados; //lista de livros
    public float currentSpeedInfor;
    public int nBooksJCorrida;
    private MovimentPlayer movimentPlayerScript;
    public int countBook { get; private set; }
    private bool instantiate; //diz se pode ou nao instanciar livros

    private void Start()
    {
        countBook = 0;
        movimentPlayerScript = FindObjectOfType<MovimentPlayer>();
        nBooksJCorrida = PlayerPrefs.GetInt("CollectedBooks", 0);

        // Se nBooksJCorrida for igual ou superior a 4, nao pode instanciar livros, pq ja pegou todos os livros
        if (nBooksJCorrida >= 4)
        {
            instantiate = false;
        }

        // Se nBooksJCorrida for menor que 4, pode instanciar livros
        if (nBooksJCorrida < 4)
        {
            instantiate = true;
        }

        //busca a lista de instanciados e verifica se contasins na lkista normal
        //NAO TA DANDO CERTO
        //FALTA VER A QUESTAO DOS LIVROS INSTANCIADOS OU NAO
        string listaInstanciadosJSON = PlayerPrefs.GetString("LivrosInstanciados", "");
        if (!string.IsNullOrEmpty(listaInstanciadosJSON))
        {
            List<GameObject> livrosInstanciados = JsonUtility.FromJson<List<GameObject>>(listaInstanciadosJSON);

            // Remover livros instanciados da lista normal de prefabs
            foreach (var livroInstanciado in livrosInstanciados)
            {
                if (prefabBook.Contains(livroInstanciado))
                {
                    prefabBook.Remove(livroInstanciado);
                }
            }
        }

    }

    void Update()
    {
        if (movimentPlayerScript.distance >= metaTakeBook && instantiate)
        {

            GameObject newBookObject = Instantiate(prefabBook[countBook], transform.position, Quaternion.identity);
            countBook++; // Próximo livro da lista
            Book newBookScript = newBookObject.GetComponent<Book>();
            newBookScript.SetBookSpeed(currentSpeedInfor);

            // Adicionar o livro à lista de livros instanciados
            livrosInstanciados.Add(newBookObject);

            metaTakeBook += increaseMetaTakeBook;

            // Atingiu o limite de 4 livros coletados
            if (nBooksJCorrida >= 4)
            {
                instantiate = false;
            }
        }
    }
}