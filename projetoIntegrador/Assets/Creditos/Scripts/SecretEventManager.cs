using UnityEngine;

public class SecretEventManager : MonoBehaviour
{
    private int clickCountObject1 = 0;
    private int clickCountObject2 = 0;
    private bool fight = false;
    private bool fight2 = false;
    public GameObject juliano;
    public GameObject ana;
    public Sprite julianoAngry;
    public Sprite anaAngry;
    public Sprite julianoPosFight;
    public Sprite anaPosFight;
    private float animationDuration = 8f;
    private float timer = 0f;

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
                    if (clickCountObject1 == 10)
                    {
                        fight = true;
                        clickCountObject1 = 0;
                    }
                }
                else if (hit.collider.gameObject.CompareTag("Juliano"))
                {
                    clickCountObject2++;
                    if (clickCountObject2 == 10)
                    {
                        fight2 = true;
                        clickCountObject2 = 0;
                    }
                }
            }
        }

        if (fight && fight2)
        {
            CallAnimation();
            fight = false;
            fight2 = false;
            timer = 0f;
        }

        if (timer >= animationDuration)
        {
            DisableAnimations();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void CallAnimation()
    {
        juliano.GetComponent<Animator>().SetBool("FightAna", true);
        juliano.GetComponent<SpriteRenderer>().sprite = julianoAngry;
        ana.GetComponent<SpriteRenderer>().sprite = anaAngry;
        ana.GetComponent<Animator>().SetBool("FightJuliano", true);
    }

    void DisableAnimations()
    {
        juliano.GetComponent<Animator>().SetBool("FightAna", false);
        ana.GetComponent<Animator>().SetBool("FightJuliano", false);
        juliano.GetComponent<SpriteRenderer>().sprite = julianoPosFight;
        ana.GetComponent<SpriteRenderer>().sprite = anaPosFight;
    }
}
