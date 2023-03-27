using DG.Tweening.Core.Easing;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float velocity;
    public Controller controller;
    public Parallax cloud;
    public Parallax cloud1;
    public Parallax mountains;
    public Parallax mountains1;
    public Parallax florest;
    public Parallax florest1;
    public Parallax tree;
    public Parallax tree1;
    public bool bb = true;
    private void Start()
    {
        controller = FindObjectOfType<Controller>();
        velocity = controller.currentObstacleSpeed;
    }
    void Update()
    {
        if (bb)
        {
            velocity = controller.currentObstacleSpeed;
            transform.Translate(-velocity * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D collison)
    {
        if (collison.gameObject.CompareTag("DestroyObstacle"))
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            bb = false;
            cloud.aa = false;
            cloud1.aa = false;
            mountains.aa = false;
            mountains1.aa = false;
            florest.aa = false;
            florest1.aa = false;
            tree.aa = false;
            tree1.aa = false;
        }
    }
}
