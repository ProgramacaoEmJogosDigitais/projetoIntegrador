using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SelectPalette : MonoBehaviour
{
    /// public Material corDaPalheta;
    public int paletteColorNumber;
    // Start is called before the first frame update
    void OnMouseOver()
    {
        this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        if (Input.GetMouseButtonUp(0))
        {
            DataPintura.selectedColorNumber = paletteColorNumber;
        }
    }
    void OnMouseExit()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
    }
}
