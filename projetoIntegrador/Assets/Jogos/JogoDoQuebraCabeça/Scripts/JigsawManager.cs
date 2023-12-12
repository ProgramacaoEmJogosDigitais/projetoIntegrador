using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JigsawManager : MonoBehaviour
{
    public RandonPositions randon;
    public GameObject instructions;
    public Image panel;

    void Start()
    {
        // Verifica se as instruções já foram exibidas antes de iniciá-las.
        if (!PlayerPrefs.HasKey("InstructionsQuebraCabeca") || PlayerPrefs.GetInt("InstructionsQuebraCabeca") == 0)
        {
            StartCoroutine(SpawnInstructions());
        }
        else
        {
            Play();
        }
    }

    public void Play()
    {
        randon.StartCoroutine(randon.RandSpriteButton());
    }
    public IEnumerator SpawnInstructions()
    {
        panel.gameObject.SetActive(true);
        instructions.SetActive(true);
        PlayerPrefs.SetInt("InstructionsQuebraCabeca", 1); // Instruções exibidas.
        yield return null;
    }

    public void GoGame()
    {
        instructions.SetActive(false);
        panel.gameObject.SetActive(false);
        randon.StartCoroutine(randon.RandSpriteButton());
    }
}
