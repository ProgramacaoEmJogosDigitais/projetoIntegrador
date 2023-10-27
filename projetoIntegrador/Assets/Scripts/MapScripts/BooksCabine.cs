using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksCabine : MonoBehaviour
{
    [SerializeField] private List<GameObject> books,booksJump;
    private int whater, quiz, run, headD;
    // Start is called before the first frame update
    void Start()
    {
        BooksPonts.pJigsaw = 4;

        if (BooksPonts.pJigsaw==4)
        {
           
                books[0].SetActive(true);
                StartCoroutine(Wait(booksJump[0]));
                
           
        }

        if(BooksPonts.pQuiz==4)
        {
           
                books[1].SetActive(true);
                StartCoroutine(Wait(booksJump[1]));
               
            
        }

        if (BooksPonts.pParkRun==4)
        {
           
                books[2].SetActive(true);
                StartCoroutine(Wait(booksJump[2]));
              
            
        }

      if(BooksPonts.pWaterfish==4)
        {
           
                books[3].SetActive(true);
                StartCoroutine(Wait(booksJump[3]));
               
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private IEnumerator Wait(GameObject  obj)
    {
        yield return new WaitForSeconds(3);
        obj.SetActive(true);
            yield return new WaitForSeconds(1.2f);
            obj.SetActive(false);
        
    }
}
