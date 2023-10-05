using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragEndDrop : MonoBehaviour
{
    public Camera cam;
   
    public Rigidbody2D rb;
    bool inPart,arrast;
    public Transform originalPosition;
    public float distance;

    void OnMouseEnter()
    {
        inPart = true;
      
    }
    private void OnMouseExit()
    {
        inPart = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();   
        arrast = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(inPart)
        {
            if(Input.GetMouseButtonDown(0))
            {
                arrast=(arrast) ? false : true;
                Debug.Log(arrast);

            }
        }
        ArrastPart();
    }

    public void ArrastPart()
    {
        if(arrast)
        {
            rb.MovePosition(cam.ScreenToWorldPoint(Input.mousePosition));
        }
        else
        {
            if(Vector2.Distance(rb.transform.position,originalPosition.position)<=distance)
            {
                rb.transform.position = originalPosition.position;
            }
        }
       
    }
}
