using DG.Tweening.Core.Easing;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float velocity;
    public Controller controller;
    public bool stopObstacle = false;

    private void Start()
    {
        stopObstacle = false;
        controller = FindObjectOfType<Controller>();
        velocity = controller.currentObstacleSpeed;
    }
    void Update()
    {
        if (!stopObstacle)
        {
            velocity = controller.currentObstacleSpeed;
            transform.Translate(-velocity * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.CompareTag("DestroyObstacle"))
        {
            Destroy(gameObject);

        }
    }
}
