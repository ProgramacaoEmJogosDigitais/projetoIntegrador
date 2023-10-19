using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksCabine : MonoBehaviour
{
    [SerializeField] private List<GameObject> books;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (BooksPonts.pJigsaw)
        {
            case 1:
                books[0].SetActive(true);
                break;
            case 2:
                books[1].SetActive(true);

                break;
            case 3:
                books[2].SetActive(true);
                break;
            case 4:
                books[3].SetActive(true);
                break;
        }

        switch (BooksPonts.pQuiz)
        {
            case 1:
                books[4].SetActive(true);
                break;
            case 2:
                books[5].SetActive(true);
                break;
            case 3:
                books[6].SetActive(true);
                break;
            case 4:
                books[7].SetActive(true);
                break;
        }

        switch (BooksPonts.pParkRun)
        {
            case 1:
                books[8].SetActive(true);
                break;
            case 2:
                books[9].SetActive(true);
                break;
            case 3:
                books[10].SetActive(true);
                break;
            case 4:
                books[11].SetActive(true);
                break;
        }

        switch (BooksPonts.pWaterfish)
        {
            case 1:
                books[12].SetActive(true);
                break;
            case 2:
                books[13].SetActive(true);
                break;
            case 3:
                books[14].SetActive(true);
                break;
            case 4:
                books[15].SetActive(true);
                break;
        }

    }
}
