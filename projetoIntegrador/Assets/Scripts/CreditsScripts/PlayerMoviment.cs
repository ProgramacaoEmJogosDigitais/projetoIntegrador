using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    // Declaração das variáveis
    private Rigidbody2D rb = null;

    public CustomImput input = null; // Variável para receber o input do jogador
    public float moveSpeed;
    public Vector2 moveVector = Vector2.zero;

    private void Awake()
    {
        input = new CustomImput();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
    }

    // OnEnable é chamado quando o script é habilitado
    private void OnEnable()
    {
        input.Enable();
        input.Player.Moviment.performed += SetMovement;
        input.Player.Moviment.canceled += SetMovement;
    }

    // OnDisable é chamado quando o script é desabilitado
    private void OnDisable()
    {
        input.Disable();
        input.Player.Moviment.performed -= SetMovement;
        input.Player.Moviment.canceled -= SetMovement;
    }

    //Lê o movimento realizado pelo jogador; Armazena a horizontal e vertical e define o movimento do jogador
    public void SetMovement(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    //Movimentação do player
    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }
}
