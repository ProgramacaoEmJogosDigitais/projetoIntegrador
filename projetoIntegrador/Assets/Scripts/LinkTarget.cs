using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkTarget : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3[] w2, a2, s2, d2;
    public Transform[] w3, a3, s3, d3;
    public Transform car, popposition;
    public GameObject popup;
    ImputManeger controler;
    public int numberWpoints;
    public bool enableUp, enableDown, enableRight, enableLeft;
    private void Awake()
    {
        controler = new ImputManeger();
        w2 = new Vector3[numberWpoints];
        a2 = new Vector3[numberWpoints];
        s2 = new Vector3[numberWpoints];
        d2 = new Vector3[numberWpoints];







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

        if (this.transform.position == car.transform.position) //se a posiçao do carro é a mesma do ponto turistico
        {

            if (!enableLeft)
            {
                a3 = null;
            }
            if (!enableUp)
            {
                w3 = null;
            }
            if (!enableRight)
            {
                d3 = null;
            }
            if (!enableDown)
            {
                s3 = null;
            }

            if (w3 != null)
            {
                for (int i = 0; i < numberWpoints; i++)
                {
                    w2[i] = w3[i].position;
                }
            }
            else
            {
                w2 = null;
            }

            if (a3 != null)
            {
                for (int j = 0; j < numberWpoints; j++)
                {

                    a2[j] = a3[j].position;

                }
            }
            else
            {
                a2 = null;
            }
            if (s3 != null)
            {
                for (int k = 0; k < numberWpoints; k++)
                {
                    s2[k] = s3[k].position;
                }
            }

            else
            {
                s2 = null;
            }

            if (d3 != null)
            {

                for (int l = 0; l < numberWpoints; l++)
                {
                    d2[l] = d3[l].position;
                }
            }

            else
            {
                d2 = null;
            }

            TargetMap.d = d2;
            TargetMap.a = a2;
            TargetMap.w = w2;
            TargetMap.s = s2;
        }

        if (controler.Imputs.Enter.triggered && TargetMap.stoped)
        {
            //Instantiate(popup,popposition.transform.position,Quaternion.identity);
            popup.SetActive(true);


            TargetMap.stoped = false;
        }

    }

}
