using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comic : MonoBehaviour
{
    [SerializeField] private GameObject comic;
    [SerializeField] private Transform posComicOnePage;
    [SerializeField] private Transform posComicTwoPages;
    [SerializeField] private float pageSpeed = 0.5f;
    [SerializeField] private List<GameObject> pagesGameObject;
    [SerializeField] private List<Image> pagesImage1;
    [SerializeField] private List<Image> pagesImage2;
    [SerializeField] private List<Sprite> pagesSprite;
    //[SerializeField] private List<Sprite> pagesSprite2;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject forwardButton;
    private int index = -1;
    private bool rotate = false;
    private float angle1;

    private void Start()
    {
        comic.transform.position = posComicOnePage.position;
        backButton.SetActive(false);

        int cont1 = 0;
        int cont2 = 0;
        for (int i = 0; i < (pagesImage1.Count + pagesImage2.Count); i++)
        {
            if (i % 2 == 0)
            {
                pagesImage1[cont1].sprite = pagesSprite[i];
                cont1++;
            }
            else
            {
                pagesImage2[cont2].sprite = pagesSprite[i];
                cont2++;
            }
        }
        pagesImage1.ForEach(image => image.gameObject.SetActive(true));
        
    }
    public void RotateForward()
    {
        if (rotate == true) { return; }
        index++;
        float angle = -180;
        pagesGameObject[index].transform.SetAsLastSibling();
        ForwardButtonActions();
        StartCoroutine(Rotate(angle, true));
        comic.transform.position = posComicTwoPages.position;
    }
    public void ForwardButtonActions()
    {
        if (backButton.activeInHierarchy == false)
        {
            comic.transform.position = posComicTwoPages.position;
            backButton.SetActive(true);
        }
        if (index + 1 == pagesGameObject.Count) //Última página
        {
            comic.transform.position = posComicOnePage.position;
            forwardButton.SetActive(false);
        }
    }
    public void RotateBack()
    {
        if (rotate == true) { return; }
        float angle = 0;
        pagesGameObject[index].transform.SetAsLastSibling();
        BackButtonActions();
        StartCoroutine(Rotate(angle, false));
    }
    public void BackButtonActions()
    {
        if (forwardButton.activeInHierarchy == false)
        {
            forwardButton.SetActive(true);
        }
        if (index - 1 == -1) // Capa
        {
            comic.transform.position = posComicOnePage.position;
            backButton.SetActive(false);
        }
     
    }
    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;

        while (true)
        {
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler(0f, angle, 0f);
            value += Time.deltaTime * pageSpeed;
            pagesGameObject[index].transform.rotation = Quaternion.Slerp(pagesGameObject[index].transform.rotation, targetRotation, value);
            angle1 = Quaternion.Angle(pagesGameObject[index].transform.rotation, targetRotation);
            Debug.Log(angle1);
            if (angle1 <= 90f && forward && index > 0)
            {
                pagesImage1[index-1].gameObject.SetActive(false); // Desativa a imagem da página 1
                pagesImage2[index-1].gameObject.SetActive(true); 
            }
            else if (angle1 <= 90f && !forward && index >0 && index < pagesGameObject.Count)
            {
                pagesImage1[index-1].gameObject.SetActive(true);   // Ativa a imagem da página 1
                pagesImage2[index - 1].gameObject.SetActive(false);

            }

            if (angle1 < 0.1f)
            {
                if (forward == false)
                {
                    index--;
                }
                rotate = false;
                break;
            }
            yield return null;
        }
    }


}
