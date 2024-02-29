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

            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img0"))
                {
                    randon.spriteFull.RemoveAt(i);
                }
            }
            randon.isPlay = true;
        }
        else if (randon.saveIndex && PlayerPrefs.HasKey("Img0"))
        {
            PlayerPrefs.SetString("Img1", PlayerPrefs.GetString("randonName"));

            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img0"))
                {
                    randon.spriteFull.RemoveAt(i);
                }
            }
            for (int j = 0; j < randon.spriteFull.Count; j++)
            {
                if (randon.spriteFull[j].name == PlayerPrefs.GetString("Img1"))
                {
                    randon.spriteFull.RemoveAt(j);
                }
            }
            randon.isPlay = true;
        }
        else if (randon.saveIndex && PlayerPrefs.HasKey("Img0") && PlayerPrefs.HasKey("Img1"))
        {
            PlayerPrefs.SetString("Img2", PlayerPrefs.GetString("randonName"));

            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img0"))
                {
                    randon.spriteFull.RemoveAt(i);
                }
            }
            for (int j = 0; j < randon.spriteFull.Count; j++)
            {
                if (randon.spriteFull[j].name == PlayerPrefs.GetString("Img1"))
                {
                    randon.spriteFull.RemoveAt(j);
                }
            }
            for (int k = 0; k < randon.spriteFull.Count; k++)
            {
                if (randon.spriteFull[k].name == PlayerPrefs.GetString("Img2"))
                {
                    randon.spriteFull.RemoveAt(k);
                }
            }
            randon.isPlay = true;
        }
    }
    private void OnDestroy()
    {
        if (randon.saveIndex)
            SaveObjectJigsaw();
    }

    public void SaveObjectJigsaw()
    {
        PlayerPrefs.SetString("randonName", randon.spriteFull[randon.index].name);
        PlayerPrefs.Save();
    }
}
