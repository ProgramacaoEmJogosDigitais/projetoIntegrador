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
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject forwardButton;
    private int index = -1;
    private bool rotate = false;

    private void Start()
    {
        comic.transform.position = posComicOnePage.position;
        backButton.SetActive(false);

        for (int i = 0; i < pagesSprite.Count; i++)
        {
            if (index % 2 == 0)
                pagesImage1[i].sprite = pagesSprite[i];
            else
                pagesImage2[i].sprite = pagesSprite[i];
        }
    }
    public void RotateForward()
    {
        if (rotate == true) { return; }
        index++;
        float angle = 180;
        ForwardButtonActions();
        pagesGameObject[index].transform.SetAsLastSibling();
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

        /*if (index == 0) //Primeira página
        {
            pagesImage[index].sprite = pagesSprite[index];
        }*/
        if (index == pagesGameObject.Count - 1) //Última página
        {
            comic.transform.position = posComicOnePage.position;
            forwardButton.SetActive(false);
        }
        /*else
        {
            pagesImage[index - 1].sprite = pagesSprite[index];
            pagesImage[index].sprite = pagesSprite[index + 1];
        }*/
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
        /*else if (index == 0) // Primeira página
        {
            pagesImage[index].sprite = pagesSprite[index];
        }
        else
        {
            pagesImage[index + 1].sprite = pagesSprite[index];
            pagesImage[index].sprite = pagesSprite[index - 1];
        }
        Debug.Log(index);
        */
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
            float angle1 = Quaternion.Angle(pagesGameObject[index].transform.rotation, targetRotation);

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
    }/*
    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        bool spriteChanged = false; // Variável para rastrear se o sprite foi alterado

        while (true)
        {
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler(0f, angle, 0f);
            value += Time.deltaTime * pageSpeed;
            pagesGameObject[index].transform.rotation = Quaternion.Slerp(pagesGameObject[index].transform.rotation, targetRotation, value);
            float angle1 = Quaternion.Angle(pagesGameObject[index].transform.rotation, targetRotation);

            // Verificar se a rotação atingiu 90 graus e o sprite ainda não foi alterado
            if (angle1 >= 90 && !spriteChanged)
            {
                spriteChanged = true;
                // Alterar o sprite da página para pagesSprite[index]
                pagesImage[index].sprite = pagesSprite[index];
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

    /* 0 = 0
     * -----
     * 0 = 1
     * 1 = 2
     * 1 = 3
     * 2 = 4
     *------
     *
     */

}
