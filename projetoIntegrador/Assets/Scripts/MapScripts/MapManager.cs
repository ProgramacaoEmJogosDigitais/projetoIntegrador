using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public GameObject scrollViewInstructions;
    public Image panel;
    public GameObject player;

    void Start()
    {
        // Verifica se as instruções já foram exibidas antes de iniciá-las.
        if (!PlayerPrefs.HasKey("InstructionsShown") || PlayerPrefs.GetInt("InstructionsShown") == 0)
        {
            StartCoroutine(SpawnInstructions());
        }
        else
        {
            StartCoroutine(ColliderVan());
        }
    }

    public IEnumerator ColliderVan()
    {
        yield return new WaitForSeconds(13.52f);
        player.GetComponent<BoxCollider2D>().enabled = true;
    }
    public IEnumerator SpawnInstructions()
    {
        yield return new WaitForSeconds(13.52f);
        panel.gameObject.SetActive(true);
        player.GetComponent<BoxCollider2D>().enabled = false;
        scrollViewInstructions.SetActive(true);
        PlayerPrefs.SetInt("InstructionsShown", 1); // Instruções exibidas.
    }

    public void GoMap()
    {
        scrollViewInstructions.SetActive(false);
        player.GetComponent<BoxCollider2D>().enabled = true;
        panel.gameObject.SetActive(false);
    }
}
