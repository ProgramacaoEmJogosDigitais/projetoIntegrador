using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JigsawManager : MonoBehaviour
{
    public RandonPositions randon;
    public GameObject instructions;
    public SpriteRenderer panel;

    private void Awake()
    {
        Time.timeScale = 1f;
    }
    void Start()
    {
        // Verifica se as instru��es j� foram exibidas antes de inici�-las.
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
        if (randon.reset != 1)
        {
            randon.saveIndex = true;
            randon.StartCoroutine(randon.RandSpriteButton());
        }
    }
    public IEnumerator SpawnInstructions()
    {
        panel.gameObject.SetActive(true);
        instructions.SetActive(true);
        PlayerPrefs.SetInt("InstructionsQuebraCabeca", 1); // Instru��es exibidas.
        yield return null;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void NoPause()
    {
        Time.timeScale = 1f;
    }
    public void GoGame()
    {
        instructions.SetActive(false);
        panel.gameObject.SetActive(false);
        randon.saveIndex = true;
        randon.StartCoroutine(randon.RandSpriteButton());
    }
}
