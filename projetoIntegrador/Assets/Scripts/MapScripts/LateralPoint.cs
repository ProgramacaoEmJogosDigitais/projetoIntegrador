using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LateralPoint : MonoBehaviour
{

    [Header("Sprites")]
    public Sprite spriteUp;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    [Header("Booleanas")]
    public bool lateralPointInitial = true;
    public bool boolUp;
    public bool boolLeft;
    public bool boolRight;

    [Header("------------------------")]

    public GameObject player;
    public GameObject pointPositionDestiny;
    public Transform pointPositionMap;
    public float transitionDuration = 0.5f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (lateralPointInitial)
            {          
                pointPositionDestiny.GetComponent<LateralPoint>().lateralPointInitial = false;
                player.transform.position = pointPositionDestiny.transform.position;
            }
            else
            {
                if (boolUp && !boolLeft && !boolRight)
                {
                    player.GetComponent<SpriteRenderer>().sprite = spriteUp; // Troca o sprite instantaneamente
                    MoveTo(pointPositionMap);
                }
                else if (!boolUp && boolLeft && !boolRight)
                {
                    player.GetComponent<SpriteRenderer>().sprite = spriteLeft;
                    MoveTo(pointPositionMap);
                }
                else if (!boolUp && !boolLeft && boolRight)
                {
                    player.GetComponent<SpriteRenderer>().sprite = spriteRight;
                    MoveTo(pointPositionMap);
                }
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
        lateralPointInitial = true;
    }

}
