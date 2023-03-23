using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float score = 0f; // pontua��o do jogador
    public TextMeshProUGUI scoreText; // refer�ncia ao componente Text que exibe a pontua��o
    [SerializeField] private float jumpForce;
    [SerializeField] private bool jump;
    [SerializeField] private bool isGrounded;
    private float baseSpeed; // pontua��o do jogador
    private float speedIncrease; // pontua��o do jogador
    private float record; // pontua��o do jogador
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private Parallax parallax;

    private void Awake()
    {
        isGrounded = true;
        playerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {
        score = 0f;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        score += Time.deltaTime; // incrementa a pontua��o com base no tempo decorrido
        scoreText.text = score.ToString("0"); // atualiza o componente Text com a nova pontua��o

        //float newSpeed = baseSpeed + (score * speedIncrease);
       // parallax.speed = newSpeed;
    }
    public void DisableInput()
    {
        playerInput.enabled = false;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        jump = context.performed;
        isGrounded = false;

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Voc� perdeu!!!");
            score = 0f;
            scoreText.text = score + "/" + record;
        }
    }


    private void FixedUpdate()
    {
        if (isGrounded && jump)
        {
            jump = false;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}


