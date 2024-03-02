using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadJigsaw : MonoBehaviour
{
    public RandonPositions randon;

    void Awake()
    {
        if (randon.saveIndex && !PlayerPrefs.HasKey("Img0"))
        {
            PlayerPrefs.SetString("Img0", PlayerPrefs.GetString("randonName"));

            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img0"))
                {
                    Debug.Log("Imagem 1 removida: "+randon.spriteFull[i].name);

                    randon.spriteFull.RemoveAt(i);
                }
            }
            randon.isPlay = true;
        }
        else if (randon.saveIndex && PlayerPrefs.HasKey("Img0") && !PlayerPrefs.HasKey("Img1"))
        {
            PlayerPrefs.SetString("Img1", PlayerPrefs.GetString("randonName"));

            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img0"))
                {
                    Debug.Log("Imagem 1 removida: " + randon.spriteFull[i].name);

                    randon.spriteFull.RemoveAt(i);
                }
            }
            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img1"))
                {
                    Debug.Log("Imagem 2 removida: " + randon.spriteFull[i].name);

                    randon.spriteFull.RemoveAt(i);
                }
            }
            randon.isPlay = true;
        }
        else if (randon.saveIndex && PlayerPrefs.HasKey("Img0") && PlayerPrefs.HasKey("Img1") && !PlayerPrefs.HasKey("Img2"))
        {
            PlayerPrefs.SetString("Img2", PlayerPrefs.GetString("randonName"));

            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img0"))
                {
                    Debug.Log("Imagem 1 removida: " + randon.spriteFull[i].name);

                    randon.spriteFull.RemoveAt(i);
                }
            }
            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img1"))
                {
                    Debug.Log("Imagem 2 removida: " + randon.spriteFull[i].name);

                    randon.spriteFull.RemoveAt(i);
                }
            }
            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img2"))
                {
                    Debug.Log("Imagem 3 removida: " + randon.spriteFull[i].name);

                    randon.spriteFull.RemoveAt(i);
                }
            }
            randon.isPlay = true;
        }
        else if (randon.saveIndex && PlayerPrefs.HasKey("Img0") && PlayerPrefs.HasKey("Img1") && PlayerPrefs.HasKey("Img2"))
        {
            PlayerPrefs.SetString("Img3", PlayerPrefs.GetString("randonName"));

            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img0"))
                {
                    Debug.Log("Imagem 1 removida: " + randon.spriteFull[i].name);

                    randon.spriteFull.RemoveAt(i);
                }
            }
            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img1"))
                {
                    Debug.Log("Imagem 2 removida: " + randon.spriteFull[i].name);

                    randon.spriteFull.RemoveAt(i);
                }
            }
            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img2"))
                {
                    Debug.Log("Imagem 3 removida: " + randon.spriteFull[i].name);

                    randon.spriteFull.RemoveAt(i);
                }
            } 
            for (int i = 0; i < randon.spriteFull.Count; i++)
            {
                if (randon.spriteFull[i].name == PlayerPrefs.GetString("Img3"))
                {
                    Debug.Log("Imagem 4 removida: " + randon.spriteFull[i].name);

                    randon.spriteFull.RemoveAt(i);
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
        Debug.Log("Imagem salva: " +randon.spriteFull[randon.index].name);
        PlayerPrefs.Save();
    }
}
