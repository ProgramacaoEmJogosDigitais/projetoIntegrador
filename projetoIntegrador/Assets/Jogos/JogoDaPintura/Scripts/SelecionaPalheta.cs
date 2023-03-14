using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionaPalheta : MonoBehaviour
{
   /// public Material corDaPalheta;
    public int numeroCorPalheta;
    // Start is called before the first frame update
    void OnMouseOver()
    {



        this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        if (Input.GetMouseButtonUp(0))
        {

            DataPintura.numeroCorSelecionada = numeroCorPalheta;


        }
    }
    void OnMouseExit()
    {
        this.transform.localScale = new Vector3(1, 1, 1);

    }
}
