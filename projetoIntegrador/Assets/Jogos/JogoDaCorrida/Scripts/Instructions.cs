using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Instructions : MonoBehaviour
{
    public GameObject panelInstructions;
    public GameObject panelPause;
    private PauseJCorrida pauseJCorrida;
    void Start()
    {
        pauseJCorrida = GetComponent<PauseJCorrida>();
        // Verifica se as instru��es j� foram exibidas antes de inici�-las.
        if (!PlayerPrefs.HasKey("InstructionsShown") || PlayerPrefs.GetInt("InstructionsShown") == 0)
        {
            pauseJCorrida.bt_pause.gameObject.SetActive(false);
            StartCoroutine(SpawnInstructions());
        }
    }

    public IEnumerator SpawnInstructions()
    {
        //bt_pause.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.01f);
        panelInstructions.gameObject.SetActive(true);
        PlayerPrefs.SetInt("InstructionsShown", 1); // Instru��es exibidas.
        Time.timeScale = 0.0f;
    }

    public void GoGame()
    {
        panelInstructions.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        pauseJCorrida.bt_pause.gameObject.SetActive(true);

    }

    public void OpenInstructions()
    {
        Time.timeScale = 0.0f;
        panelPause.SetActive(false);
        panelInstructions.gameObject.SetActive(true);

    }
}
