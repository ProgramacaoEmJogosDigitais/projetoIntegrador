using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadJigsaw : MonoBehaviour
{
    public RandonPositions randon;

    void Start()
    {
        if (randon.saveIndex && !PlayerPrefs.HasKey("Img0"))
        {
            PlayerPrefs.SetString("Img0", PlayerPrefs.GetString("randonName"));

            Debug.Log("img zero: " + PlayerPrefs.GetString("Img0"));
            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                Debug.Log(i);

                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img0"))
                {
                    randon.spriteFull.RemoveAt(i);
                }
            }
        }
        else if (randon.saveIndex && PlayerPrefs.HasKey("Img0"))
        {
            PlayerPrefs.SetString("Img1", PlayerPrefs.GetString("randonName"));

            Debug.Log("img um: " + PlayerPrefs.GetString("Img1"));

            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img0"))
                {
                    randon.spriteFull.RemoveAt(i);
                }
            }
            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img1"))
                {
                    randon.spriteFull.RemoveAt(i);
                }
            }
        }
    }
    private void OnDestroy()
    {
        if (randon.saveIndex)
            SaveObjectJigsaw();
    }

    public void SaveObjectJigsaw()
    {
        PlayerPrefs.SetString("randonName", randon.spriteRenderer.sprite.name);
        Debug.Log("Index  : " + PlayerPrefs.GetString("randonName"));
    }
}
