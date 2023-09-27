using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonumentIntantiate : MonoBehaviour
{
    public List<GameObject> monuments;
    public GameObject monumentToDestroy;
    public Collider2D finalPoint;
    public Transform initialPont;
    public float vel;
    public int index;
    bool isDetroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Monument")
        {
            DestroiMonumenst();
        }
    }
  
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        isDetroy = true;
    }
    void FixedUpdate()
    {

        SpamMonument();


    }
    // Update is called once per frame
    void Update()
    {
        
    }
   



    void SpamMonument()
    {
        if(isDetroy)
        {
            Instantiate(monuments[index],initialPont);
            isDetroy=false;
        }
    }
    void DestroiMonumenst()
    {
        monumentToDestroy = GameObject.FindGameObjectWithTag("Monument");
        if (monumentToDestroy.transform.position.x < finalPoint.transform.position.x )
        {
            Destroy(monuments[index]);
            isDetroy = true;
            index++;
            if(index > monuments.Count)
            {
                index=0;
            }
        }
    }

}
