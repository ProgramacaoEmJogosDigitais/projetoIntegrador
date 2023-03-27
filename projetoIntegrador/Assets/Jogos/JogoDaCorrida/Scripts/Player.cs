using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float jumpForce;
    [SerializeField] private bool jump;
    [SerializeField] private bool isGrounded;

    public Controller controller;
    public InstatiateObstacle position;
    public Obstacle obstacle;
    public Parallax cloud;
    public Parallax cloud1;
    public Parallax mountains;
    public Parallax mountains1;
    public Parallax florest;
    public Parallax florest1;
    public Parallax tree;
    public Parallax tree1;
    public GameObject gameOver;


    //private float record; // pontuação do jogador
    private Rigidbody2D rb;
    private PlayerInput playerInput;

    private void Awake()
    {
        isGrounded = true;
        playerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            Debug.Log("Você perdeu!!!");
            controller.Clean();
            position.stopInstatiateObstacle = true;
            obstacle.stopObstacle = true;
            cloud.stopParallax = true;
            cloud1.stopParallax = true;
            mountains.stopParallax = true;
            mountains1.stopParallax = true;
            florest.stopParallax = true;
            florest1.stopParallax = true;
            tree.stopParallax = true;
            tree1.stopParallax = true;
            gameOver.SetActive(true);
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


