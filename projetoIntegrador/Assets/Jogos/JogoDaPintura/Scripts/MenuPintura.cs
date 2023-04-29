using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPintura : MonoBehaviour
{
    public GameObject menuPintura, menuSelecaoPintura;

    public void AlnternaMenuPintura()
    {
        menuPintura.SetActive(false);
        menuSelecaoPintura.SetActive(true);
    }

}
