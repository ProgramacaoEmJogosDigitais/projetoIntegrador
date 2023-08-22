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
        StartCoroutine(FadeSystem());
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
    public void ChangeSceneEvent()
    {

        SceneManager.LoadScene(menuSceneName);
    }
    public IEnumerator FadeSystem()
    {
        Color colorImage = componentImage.GetComponent<Image>().color;
        colorImage.a = 0.0f;
        componentImage.GetComponent<Image>().color = colorImage;
        componentImage.gameObject.SetActive(true) ;
        componentImage.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(3);
    }
}