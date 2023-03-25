using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 [] w2, a2, s2, d2;
    public Transform [] w3, a3, s3, d3;
    public Transform  car, popposition;
    public GameObject popup;
    ImputManeger controler;


   

    private void Awake()
    {
        controler = new ImputManeger();
        for (int i = 0; i < w3.Length; i++)
        {
            w2[i] = w3[i].position;
            a2[i] = a3[i].position;
            s2[i] = s3[i].position;
            d2[i] = d3[i].position;
        }

    }
    private void OnEnable()
    {
        controler.Enable();
    }
    private void OnDisable()
    {
        controler.Disable();
    }



    void Start()
    {
        TargetMap.stoped = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        Chegou();

    }
    void Chegou()
    {
        if(this.transform.position==car.transform.position)
        {

            TargetMap.d = d2;
            TargetMap.a = a2;
            TargetMap.w = w2;
            TargetMap.s = s2;
            
            
        }

        if(controler.Imputs.Enter.triggered && TargetMap.stoped)
        {
            //Instantiate(popup,popposition.transform.position,Quaternion.identity);
            popup.SetActive(true);  
           
                
            TargetMap.stoped=false;
        }
    }
}
