using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelecionaPintura : MonoBehaviour
{
    public GameObject[] pinturas;
 
    public  Material []mateiaisPintura, mateiaisFilhosPintura;
    public Material semCorPintura,corSelecionada;

     public int numeroPintura;
    // Start is called before the first frame update

    void Start()
    {
        ApagaPintura();
        numeroPintura = Random.Range(0, pinturas.Length);
        pinturas[numeroPintura].SetActive(true);
    
    }
    public void AlternaPintura()
    {
        ApagaPintura(); 
        numeroPintura = Random.Range(0, pinturas.Length);
        pinturas[numeroPintura].SetActive(true);
  

    }
    void ApagaPintura()
    {
        ResetaPintura();
        for (int i = 0; i < pinturas.Length; i++)
        {
            pinturas[i].SetActive(false);
        }
    }
    public void ApertaReset()
    {
        ResetaPintura();    
    }

    void ResetaPintura()
    {
        Debug.Log("entro reset");

       
        Debug.Log("passo reset");

        
        for (int i = 0; i < mateiaisFilhosPintura.Length; i++)
        {
            mateiaisFilhosPintura[i].color = semCorPintura.color;
           
        }
     
      
    }
    // Update is called once per frame
   
}
