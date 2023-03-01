using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform w2, a2, s2, d2, car, popposition;
    public GameObject popup;
    ImputManeger controler;


   

    private void Awake()
    {
        controler = new ImputManeger();
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
