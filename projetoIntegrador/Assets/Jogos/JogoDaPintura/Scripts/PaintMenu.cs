using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintMenu : MonoBehaviour
{
    public GameObject paintMenu, paintMenuSelection;

    public void AlnternaMenuPintura()
    {
        paintMenu.SetActive(false);
        paintMenuSelection.SetActive(true);
    }

}
