using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour
{
    public Canvas scrollViewInstructions;
    void Start()
    {
        StartCoroutine(Spawinstructions());   
    }

    public IEnumerator Spawinstructions()
    {
            yield return new WaitForSeconds(1);
            scrollViewInstructions.gameObject.SetActive(true);
    }

    public void GoMap()
    {
        Destroy(scrollViewInstructions.gameObject);
    }
}
