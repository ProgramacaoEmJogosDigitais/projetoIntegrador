using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour
{
    [Header("Posições")]
    public Transform pointUp;
    public Transform pointDown;
    public Transform pointLeft;
    public Transform pointRight;

    [Header("Sprites")]
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    public GameObject player;
    public float transitionDuration = 0.5f;

    private VanMoviment vanMoviment;
    private bool isColliding = false;

    private void Start()
    {
        vanMoviment = player.GetComponent<VanMoviment>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = false;
        }
    }

    private void Update()
    {
        if (isColliding && !vanMoviment.isMoving)
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.GetComponent<SpriteRenderer>().sprite = spriteUp; // Troca o sprite instantaneamente
                MoveTo(pointUp);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                player.GetComponent<SpriteRenderer>().sprite = spriteDown;
                MoveTo(pointDown);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                player.GetComponent<SpriteRenderer>().sprite = spriteLeft;
                MoveTo(pointLeft);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                player.GetComponent<SpriteRenderer>().sprite = spriteRight;
                MoveTo(pointRight);
            }
        }
    }

    void MoveTo(Transform target)
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;

            // Calcula a direção para onde a van/player está se movendo
            Vector3 moveDirection = (targetPosition - player.transform.position).normalized;

            // Calcula o ângulo de rotação em radianos
            float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

            // Rotaciona a van/player ligeiramente na direção do movimento
            player.transform.rotation = Quaternion.Euler(0, 0, targetAngle);

            StartCoroutine(TransitionPlayer(targetPosition));
        }
    }

    IEnumerator TransitionPlayer(Vector3 targetPosition)
    {
        vanMoviment.isMoving = true;
        Vector3 startingPos = player.transform.position;

        float elapsedTime = 0;

        while (elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;
            player.transform.position = Vector3.Lerp(startingPos, targetPosition, t);

            // Adiciona translação ao longo do eixo z
            float zOffset = Mathf.Lerp(0, 1, t) * 0.2f; // Ajuste o valor 0.2f conforme necessário
            Vector3 positionWithOffset = player.transform.position + player.transform.forward * zOffset;
            player.transform.position = positionWithOffset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.transform.position = targetPosition;

        vanMoviment.isMoving = false;
    }

}
