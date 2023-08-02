using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private LinkTarget linkTarget;
    
    void Start()
    {
        linkTarget = GetComponent<LinkTarget>();
    }

    public void Pointinteraction()
    {
        if (linkTarget.atPoint)
        {
            this.transform.GetChild(0).localScale = new Vector3(transform.localScale + 2f, transform.localScale + 2f, transform.localScale + 2f);
        }
    }
}
