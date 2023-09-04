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
    public float timeToArrive;
    ImputManeger controler;

    private void Awake()
    {
        controler = new ImputManeger();
    }
    void Update()
    {
        Path();
    }
    private void OnEnable()
    {
        controler.Enable();
    }
    private void OnDisable()
    {
        controler.Disable();
    }
    void Path()
    {
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
