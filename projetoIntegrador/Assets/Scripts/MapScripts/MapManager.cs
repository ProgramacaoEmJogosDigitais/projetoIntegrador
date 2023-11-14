using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public Canvas scrollViewInstructions;
    public Image panel;
    public GameObject player;
    void Start()
    {
        // Verifica se as instru��es j� foram exibidas antes de inici�-las.
        if (!PlayerPrefs.HasKey("InstructionsShown") || PlayerPrefs.GetInt("InstructionsShown") == 0)
        {
            StartCoroutine(SpawnInstructions());
        }
    }

    public IEnumerator SpawnInstructions()
    {
        yield return new WaitForSeconds(1);
        panel.gameObject.SetActive(true);
        player.GetComponent<VanMoviment>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
        scrollViewInstructions.gameObject.SetActive(true);
        PlayerPrefs.SetInt("InstructionsShown", 1); // Instru��es exibidas.
    }

    public void GoMap()
    {
        scrollViewInstructions.gameObject.SetActive(false);
        player.GetComponent<VanMoviment>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        panel.gameObject.SetActive(false);
    }
}
