using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectPaint : MonoBehaviour
{
     public GameObject[] pictures;
     public  Material [] paintingMaterials, materialsSonPainting;
     public Material noColorPainting, colorSelected;
     public int numberPicture;

    // Start is called before the first frame update

    void Start()
    {
        ErasePainting();
        numberPicture = Random.Range(0, pictures.Length);
        pictures[numberPicture].SetActive(true);
    
    }
    public void TogglePainting() //Alterna figura
    {
        ErasePainting();
        numberPicture = Random.Range(0, pictures.Length);
        pictures[numberPicture].SetActive(true);
  

    }
    void ErasePainting() //Apaga figura
    {
        ResetPicture();
        for (int i = 0; i < pictures.Length; i++)
        {
            pictures[i].SetActive(false);
        }
    }
    public void PressReset() //aperta reset
    {
        ResetPicture();    
    }

    void ResetPicture()
    {
        Debug.Log("entro reset");//TODO
        Debug.Log("passo reset");//TODO

        for (int i = 0; i < materialsSonPainting.Length; i++)
        {
            materialsSonPainting[i].color = noColorPainting.color;
           
        }
     
      
    }
    // Update is called once per frame
   
}
