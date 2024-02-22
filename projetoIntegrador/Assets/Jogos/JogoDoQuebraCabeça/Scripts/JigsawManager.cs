using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class JigsawManager : MonoBehaviour
{
    public RandonPositions randon;
    public GameObject instructions;
    public SpriteRenderer panel;
    public Comic comic;
    public List<DragEndDrop> dragEndDrop;
    private void Awake()
    {
        randon.pause = false;
        DragEndDrop[] dragEndDropArray = FindObjectsOfType<DragEndDrop>();

        // Inicializar a lista com os objetos encontrados
        dragEndDrop = new List<DragEndDrop>(dragEndDropArray);

    }
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
        PlayerPrefs.SetInt("InstructionsQuebraCabeca", 1); // Instruções exibidas.
        yield return null;
    }
    public void Pause()
    {
        DisableParts();
        randon.pause = true;
    }
    public void NoInstruction()
    {
        randon.pause = false;
    }
    public void NoPause()
    {
        EnableParts();
        randon.pause = false;
    }
    public void GoGame()
    {
        instructions.SetActive(false);
        panel.gameObject.SetActive(false);
        randon.saveIndex = true;
        randon.StartCoroutine(randon.RandSpriteButton());
        comic.rotate = false;
        comic.ResetComic(); 
    }
    public void DisableParts()
    {
        for (int i = 0; i < dragEndDrop.Count; i++)
        {
            dragEndDrop[i].blockMove = false;
        }
    }
    public void EnableParts()
    {
        for (int i = 0; i < dragEndDrop.Count; i++)
        {
            dragEndDrop[i].blockMove = true;
        }
    }
}
