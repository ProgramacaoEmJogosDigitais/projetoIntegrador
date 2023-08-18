using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{    
    public Image componentImage;
    public Canvas canvas;
    private void Start()
    {
        StartCoroutine(FadeSystem());

    }


    public IEnumerator FadeSystem()
    {
        componentImage.gameObject.SetActive(true);
        //canvas.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);
        ////Fade in (Aparece a tela escura -> alfa = 1)
        //Fade out (tela trasparente -> escura.alfa = 0)
        componentImage.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(3);
    }
}
