using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColeta : MonoBehaviour
{
    public float playerSpeed = 5f;
    public static int missingObjects = 0;
    public bool playerTrash;

    SpriteRenderer playerFlip;
    private Animator pAnimator;
    private BoxCollider2D playerCollider;
    private int playerRunState;
    private int playerIdleState;
    private int idleLixoState;
    private int runLixoState;

    private void Awake()
    {
        playerFlip = GetComponent<SpriteRenderer>();
        pAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();

        playerRunState = Animator.StringToHash("PlayerRun");
        playerIdleState = Animator.StringToHash("PlayerIdle");
        idleLixoState = Animator.StringToHash("IdleLixo");
        runLixoState = Animator.StringToHash("RunLixo");
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        transform.Translate(Time.deltaTime * playerSpeed * movement);

        if (horizontalInput > 0)
        {
            playerFlip.flipX = false;
            playerCollider.offset = new Vector2(3.88f, 2.34f);
        }
        else if (horizontalInput < 0)
        {
            playerFlip.flipX = true;
            playerCollider.offset = new Vector2(-3.88f, 2.34f);
        }

        if (horizontalInput == 0)
        {
            pAnimator.Play(playerIdleState);
            if (playerTrash)
                pAnimator.Play(idleLixoState);
        }
        else if (horizontalInput != 0)
        {
            pAnimator.Play(playerRunState);
            if (playerTrash)
                pAnimator.Play(runLixoState);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fish") && playerTrash)
        {
            Debug.Log("colidiu no player.");
            // Destruir o objeto pego
            Destroy(other.gameObject);

            // Aumentar os erros
            PlayerColeta.MissingObject();
        }

        if (other.CompareTag("lixo") && playerTrash)
        {
            Debug.Log("colidiu no player.");
            // Destruir o objeto pego
            Destroy(other.gameObject);

            // Aumentar os pontos
            ObjectsFalling.pointsTrash++;
        }

        if (other.CompareTag("lixo") && !playerTrash)
        {
            Debug.Log("colidiu no player.");
            // Destruir o objeto pego
            Destroy(other.gameObject);

            // Aumentar os erros
            PlayerColeta.MissingObject();
        }
    }
}
