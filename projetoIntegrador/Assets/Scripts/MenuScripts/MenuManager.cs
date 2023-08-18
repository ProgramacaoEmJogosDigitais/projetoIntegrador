using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string menuSceneName;
    [SerializeField] private GameObject panelMainMenu;
    [SerializeField] private GameObject panelOptions;
    //public FadeInOut fadeInOut;
    public Image componentImage;
    public Canvas canvas;

    public void Play()
    {
        Debug.Log("1");
        StartCoroutine(FadeSystem());
        Debug.Log("2");

        //InvokeFade();
        //SceneManager.LoadScene(menuSceneName);
    }

    public void OpenOptions()
    {
        panelMainMenu.SetActive(false);
        panelOptions.SetActive(true);
    }

    public void CloseOptions()
    {
        panelOptions.SetActive(false);
        panelMainMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    //public IEnumerator InvokeFade()
    //{        yield return new WaitForSeconds(3);

    //    fadeInOut.StartCoroutine(fadeInOut.FadeSystem());

    //}
    public void ChangeSceneEvent()
    {

        SceneManager.LoadScene(menuSceneName);
    }
    public IEnumerator FadeSystem()
    {
        Debug.Log("3");
        Color colorImage = componentImage.GetComponent<Image>().color;
        colorImage.a = 0.0f;
        componentImage.GetComponent<Image>().color = colorImage;
        componentImage.gameObject.SetActive(true) ;
        //canvas.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);
        ////Fade in (Aparece a tela escura -> alfa = 1)
        componentImage.GetComponent<Animator>().SetTrigger("In");
        Debug.Log("4");
        yield return new WaitForSeconds(3);
        //Debug.Log("5");



        //Debug.Log("6");

        //Fade out (tela trasparente->escura.alfa = 0)
        //componentImage.GetComponent<Animator>().SetTrigger("Out");
        //yield return new WaitForSeconds(3);
        //Debug.Log("7");

    }
}