using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class VanMoviment : MonoBehaviour
{
    public CustomImput input = null; // Variável para receber o input do jogador
    public float moveSpeed;
    public Vector2 moveVector = Vector2.zero;
    public Sprite spriteVanUp;
    public Sprite spriteVanDown;
    public Sprite spriteVanRight;
    public Sprite spriteVanLeft;

    public Transform posInitial;
    public bool isMoving = false;
    private void Awake()
    {
        input = new CustomImput();
    }
    private void Start()
    {
        transform.position = posInitial.position;
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
}
