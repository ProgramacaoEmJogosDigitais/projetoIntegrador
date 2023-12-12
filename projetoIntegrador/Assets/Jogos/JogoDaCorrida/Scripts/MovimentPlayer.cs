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
    public float speedPoints;
    public float increaseSpeedPoints;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool jump;
    [SerializeField] private bool isGrounded = true;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    PlayerInputActions input;
    public float distance { private set; get; } 
    private GameControllerJCorrida gameController;
    private Progression progressionScript;
    public TMP_Text distanceText;
    public bool progressMovimentPScript;


    private void Awake()
    {
        input = new PlayerInputActions();
        playerInput = GetComponent<PlayerInput>();
        gameController = FindObjectOfType<GameControllerJCorrida>();
        progressionScript = FindObjectOfType<Progression>();
        progressMovimentPScript = false;

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
            jump = false;
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
        if (progressionScript.atingiuAMeta)
        {
            Debug.Log("ATINGIUUUU");
            progressMovimentPScript = true;
            speedPoints = speedPoints + increaseSpeedPoints;
            Debug.Log("aaaaa"+speedPoints);
        }

    }

    void UpdateDistanceText()
    {
        distanceText.text = distance.ToString("F0");
    }

}
