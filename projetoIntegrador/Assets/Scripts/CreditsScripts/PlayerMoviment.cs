using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    // Declara��o das vari�veis
    private Rigidbody2D rb = null;

    public CustomImput input = null; // Vari�vel para receber o input do jogador
    public float moveSpeed;
    public Vector2 moveVector = Vector2.zero;

    private void Awake()
    {
        input = new CustomImput();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Define a posi��o inicial da c�mera
        Vector3 initialPosition = new Vector3(4f, -2.3f, transform.position.z);
        transform.position = initialPosition;

    }

    // OnEnable � chamado quando o script � habilitado
    private void OnEnable()
    {
        input.Enable();
        input.Player.Moviment.performed += SetMovement;
        input.Player.Moviment.canceled += SetMovement;
    }

    // OnDisable � chamado quando o script � desabilitado
    private void OnDisable()
    {
        input.Disable();
        input.Player.Moviment.performed -= SetMovement;
        input.Player.Moviment.canceled -= SetMovement;
    }

    //L� o movimento realizado pelo jogador; Armazena a horizontal e vertical e define o movimento do jogador
    public void SetMovement(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    //Movimenta��o do player
    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }
}