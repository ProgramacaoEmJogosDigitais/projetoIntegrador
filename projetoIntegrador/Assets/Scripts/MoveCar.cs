using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class MoveCar : MonoBehaviour
{
   // public Transform[] pontos;
    public Transform car;
    ImputManeger controler;
  
    
    public float timeToArrive;

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

    // Start is called before the first frame update
    void Start()
    {
      
       



    }

    // Update is called once per frame
    void Update()
    {
        Caminho();
      
    }
  
 
    void Caminho()
    {
       


        if (controler.Imputs.Up.triggered && TargetMap.stoped)
        {
            
            if(TargetMap.w!=null)
            {
                car.transform.DOMove(TargetMap.w.position, timeToArrive).OnComplete(() =>
                {
                    TargetMap.stoped = true;

                });

                TargetMap.stoped = false;

            }
           



        }
        

        if (controler.Imputs.Down.triggered && TargetMap.stoped)
        {

            if(TargetMap.s!= null)
            {
                car.transform.DOMove(TargetMap.s.position, timeToArrive).OnComplete(() =>
                {
                    TargetMap.stoped = true;


                });

                TargetMap.stoped = false;
            }
           



        }

        if (controler.Imputs.Left.triggered && TargetMap.stoped)
        {

          if(TargetMap.a!=null) 
          {
                car.transform.DOMove(TargetMap.a.position, timeToArrive).OnComplete(() =>
                {
                    TargetMap.stoped = true;

                });

                TargetMap.stoped = false;

          }
            

        }
        if (controler.Imputs.Rigth.triggered && TargetMap.stoped)
        {
           

            if(TargetMap.d!=null)
            {
                car.transform.DOMove(TargetMap.d.position, timeToArrive).OnComplete(() =>
                {
                    TargetMap.stoped = true;




                });

                TargetMap.stoped = false;
            }
           





        }

    }
}
