using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float parallaxLength, parallaxposition;
    public float parallaxEffect;
    public GameObject cam;


    // Start is called before the first frame update
    void Start()
    {
        parallaxposition = transform.position.x;
        parallaxLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float time = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxposition);

        transform.position = new Vector3(parallaxposition + distance, transform.position.y, transform.position.z);

        if (time > parallaxposition + parallaxLength)
        {
            parallaxposition += parallaxLength;
        }
        else if (time < parallaxposition - parallaxLength)
        {
            parallaxposition -= parallaxLength;
        }  
    }

}
