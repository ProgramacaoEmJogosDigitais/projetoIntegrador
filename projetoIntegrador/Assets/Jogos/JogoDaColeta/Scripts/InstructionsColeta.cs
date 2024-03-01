using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InstructionsColeta : MonoBehaviour
{
    public GameObject panelInstructions;
    public GameObject btn_pause;
    public GameObject btn_exit;

    private GameControllerJC gameController;

    void Start()
    {
        //gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerJC>();
        
        // Verifica se as instru��es j� foram exibidas antes de inici�-las.
        if (!PlayerPrefs.HasKey("InstructionsColeta") || PlayerPrefs.GetInt("InstructionsColeta") == 0)
        {
            StartCoroutine(SpawnInstructions());
        }


    }

    public IEnumerator SpawnInstructions()
    {
        yield return new WaitForSeconds(0.01f);
        panelInstructions.gameObject.SetActive(true);
        btn_exit.gameObject.SetActive(false);
        btn_pause.gameObject.SetActive(false);
        PlayerPrefs.SetInt("InstructionsColeta", 1); // Instru��es exibidas.

        //gameController.PauseGame();
        
    }

    public void GoGame()
    {
        panelInstructions.gameObject.SetActive(false);
        //Time.timeScale = 1.0f; MUDAR

    }

    public void OpenInstructions()
    {
        //Time.timeScale = 0.0f; MUDAR
        panelInstructions.gameObject.SetActive(true);
        btn_exit.gameObject.SetActive(false);
        btn_pause.gameObject.SetActive(false);
    }
}
