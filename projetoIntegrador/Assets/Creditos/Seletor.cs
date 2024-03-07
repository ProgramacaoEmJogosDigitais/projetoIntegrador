using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Seletor : MonoBehaviour
{
    public TextMeshProUGUI description;
    public string name;
    public Sprite photos;
    public Image photoGame;

    void OnMouseEnter()
    {
        Debug.Log("Mouse está sobre: " + gameObject.name);
        photoGame.GetComponent<Image>().sprite = photos;
        description.text = name;
    }
}
