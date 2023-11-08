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
    private CircleCollider2D playerCollider;

    private void Awake()
    {
        playerFlip = GetComponent<SpriteRenderer>();
        pAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        transform.Translate(Time.deltaTime * playerSpeed * movement);

        if (horizontalInput > 0)
        {
            CircleCollider2D.offset.x = 0.79;
            playerFlip.flipX = false;
            playerCollider.offset = new Vector2(3.88f, 2.34f);
        }
        else if (horizontalInput < 0)
        {
            CircleCollider2D.offset.x = -0.79;
            playerFlip.flipX = true;
            playerCollider.offset = new Vector2(-3.88f, 2.34f);
        }
        if (horizontalInput == 0)
        {
            pAnimator.Play("PlayerIdle");
        }
        else if (horizontalInput != 0)
        {
            pAnimator.Play("PlayerRun");
        }

        if (transform.position.x > 8f)
        {
            transform.position = new Vector2(8f, transform.position.y);
        }
        else if (transform.position.x < -8f)
        {
            transform.position = new Vector2(-8f, transform.position.y);
        }
    }

    public static void MissingObject()
    {
        missingObjects++;
      
    }
}