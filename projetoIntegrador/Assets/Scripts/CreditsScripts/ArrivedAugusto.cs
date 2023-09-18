using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrivedAugusto : MonoBehaviour
{
    public Canvas popUpInformations;
    public Image imagemAugusto;
    private bool collisionPlayer = false;
    private bool popUp = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (collisionPlayer)
        {
            Debug.Log("Entrou");//TODO
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Debug.Log("APertoru");//TODO
                popUpInformations.gameObject.SetActive(true);
                popUp = true;
                StartCoroutine(DesaparecerImage());
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Saiu"); //TODO
            collisionPlayer = false;
            popUp = false;
            popUpInformations.gameObject.SetActive(false);


        }
    }
    private IEnumerator DesaparecerImage()
    {
        if (popUp)
        {
            yield return new WaitForSeconds(1);
            imagemAugusto.gameObject.SetActive(false);
        }
        
    }
}
