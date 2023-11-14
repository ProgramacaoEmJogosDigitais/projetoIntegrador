using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class MovimentPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 6;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool jump;
    [SerializeField] private bool isGrounded = true;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    PlayerInputActions input;
    private float distance; 
    public TMP_Text distanceText;

    private void Awake()
    {
        input = new PlayerInputActions();
        playerInput = GetComponent<PlayerInput>();
        
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
        jump = context.performed;
        if ()//VERIFICAR A POSICAO DO PLAYER SE MUDOU
        {
            isGrounded = false;
        }
        
    }

    void OnCollisionStay2D(Collision2D collision) // verifica se ta no chao
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded && jump)
        {
            jump = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }

    }
    void Update()
    {
        distance += Time.deltaTime * speed;

        UpdateDistanceText();
    }

    void UpdateDistanceText()
    {
        if (distanceText != null)
        {
            distanceText.text = distance.ToString("F0") ; 
        }
    }

}
