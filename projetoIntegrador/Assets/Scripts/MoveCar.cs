using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class MoveCar : MonoBehaviour
{
   // public Transform[] wpoints;
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
       /*
        
        
        */


        if (controler.Imputs.Up.triggered && TargetMap.stoped)
        {
            
            if(TargetMap.w!=null)
            {
                car.transform.DOPath(TargetMap.w, timeToArrive,PathType.CatmullRom,PathMode.Sidescroller2D).SetEase(Ease.Linear).SetLookAt(0).OnComplete(() =>
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
                car.transform.DOPath(TargetMap.s, timeToArrive, PathType.CatmullRom, PathMode.Sidescroller2D).SetEase(Ease.Linear).SetLookAt(0).OnComplete(() =>
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
                car.transform.DOPath(TargetMap.a, timeToArrive, PathType.CatmullRom, PathMode.Sidescroller2D).SetEase(Ease.Linear).SetLookAt(2).OnComplete(() =>
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
                car.transform.DOPath(TargetMap.d, timeToArrive, PathType.CatmullRom, PathMode.Sidescroller2D).SetEase(Ease.Linear).SetLookAt(0).OnComplete(() =>
                {
                    TargetMap.stoped = true;

                });

                TargetMap.stoped = false;
            }
           





        }

    }
}
