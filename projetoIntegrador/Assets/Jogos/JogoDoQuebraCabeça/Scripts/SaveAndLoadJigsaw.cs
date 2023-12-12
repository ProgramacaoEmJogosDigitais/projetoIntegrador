using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadJigsaw : MonoBehaviour
{
    public RandonPositions randon;

    private void Start()
    {

    }

    private void OnDestroy()
    {
        SaveObjectJigsaw();
    }

    public void SaveObjectJigsaw()
    {
         PlayerPrefs.SetInt("position", randon.index);
    }
}
