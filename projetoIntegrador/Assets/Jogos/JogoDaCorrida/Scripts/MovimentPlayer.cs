using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class MovimentPlayer : MonoBehaviour
{
    public float speedPoints = 6;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = true;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    PlayerInputActions input;
    public float distance { private set; get; } 
    private GameControllerJCorrida gameController;
    public TMP_Text distanceText;

    private void Awake()
    {
        input = new PlayerInputActions();
        playerInput = GetComponent<PlayerInput>();
        gameController = FindObjectOfType<GameControllerJCorrida>();

    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distance = 0f;
    }

    private void OnEnable() // executado quando um objeto é ativado
    {
        input.Enable();
    }

    private void OnDisable() //quando desativado
    {
        input.Disable();
    }

    public void DisableInput()
    {
        playerInput.enabled = false;
    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (isGrounded)
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    void OnCollisionEnter2D(Collision2D collision) // verifica se ta no chao
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("COLIDIU");
            gameController.gameOver = true;
            rb.velocity = Vector3.zero;
        }
    }
    void Update()
    {
        if (!gameController.gameOver)
        {
            distance += Time.deltaTime * speedPoints;
            UpdateDistanceText();
        }

    }

    void UpdateDistanceText()
    {
        distanceText.text = distance.ToString("F0");
    }

}
