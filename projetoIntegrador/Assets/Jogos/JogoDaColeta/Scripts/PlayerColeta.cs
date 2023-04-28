using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerColeta : MonoBehaviour
{
    public float playerSpeed = 5f;
    public static int missingObjects = 0;

    SpriteRenderer playerFlip;
    private Animator pAnimator;

    private void Awake()
    {
        playerFlip = GetComponent<SpriteRenderer>();
        pAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        transform.Translate(Time.deltaTime * playerSpeed * movement);

        if (horizontalInput > 0)
        {
            playerFlip.flipX = false;
        }

        else if (horizontalInput < 0)
        {
            playerFlip.flipX = true;
        }
        if (horizontalInput == 0)
        {
            pAnimator.Play("PlayerIdle");
        }
        else if (horizontalInput != 0)
        {
            pAnimator.Play("PlayerRun");
        }
    }

    public static void MissingObject()
    {
        missingObjects++;
        if (missingObjects >= GameControllerJC.lostObjectsForGameOver)
        {
            // Game over!
            GameControllerJC.GameOver();
        }
    }
}