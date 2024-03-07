using UnityEngine;

public class SecretEventManager : MonoBehaviour
{
    private int clickCountObject1 = 0;
    private int clickCountObject2 = 0;
    public bool fight = false;
    public bool fight2 = false;
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

         
            if (hit.collider != null)
            {
             
                if (hit.collider.gameObject.CompareTag("Ana"))
                {
                   
                    clickCountObject1++;

                   
                    if (clickCountObject1 == 3)
                    {
                        fight = true;
                    }
                }
                else if (hit.collider.gameObject.CompareTag("Juliano"))
                {
                   
                    clickCountObject2++;

               
                    if (clickCountObject2 == 4)
                    {
                        fight2 = true;
                    }
                }
            }
        }
        if(fight && fight2)
        {
            CallAnimation();
            fight = false;
            fight2 = false;
        }
    }

    void CallAnimation()
    {
        Debug.Log("Chamou o evento secreto para o objeto 1");
    }

    
}
