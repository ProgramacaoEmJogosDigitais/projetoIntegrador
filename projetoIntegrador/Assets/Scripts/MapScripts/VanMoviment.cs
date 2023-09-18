using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class VanMoviment : MonoBehaviour
{
    public Transform posInitial;
    public bool isMoving = false;
    private void Start()
    {
        transform.position = posInitial.position;
    }
}

    /*// Declara��o das vari�veis
    private Rigidbody2D rb = null;

    public CustomImput input = null; // Vari�vel para receber o input do jogador
    public float moveSpeed;
    public Vector2 moveVector = Vector2.zero;
    public Sprite spriteVanUp;
    public Sprite spriteVanDown;
    public Sprite spriteVanRight;
    public Sprite spriteVanLeft;

    private void Awake()
    {
        input = new CustomImput();
        rb = GetComponent<Rigidbody2D>();
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
        Driving();
    }
    public void Driving()
    {
        // Define a anima��o com base na dire��o do movimento
        if (moveVector.y > 0 && moveVector.x == 0) //Cima
        {
            GetComponent<SpriteRenderer>().sprite = spriteVanUp;
            GetComponent<BoxCollider2D>().size = new Vector2(1.14f, 2.7f);
        }
        else if (moveVector.y < 0 && moveVector.x == 0) //Baixo
        {
            GetComponent<SpriteRenderer>().sprite = spriteVanDown;
            GetComponent<BoxCollider2D>().size = new Vector2(1.14f, 2.7f);
        }
        else if (moveVector.x > 0) //Direita
        {
            GetComponent<SpriteRenderer>().sprite = spriteVanRight;
            GetComponent<BoxCollider2D>().size = new Vector2(2.7f, 1.14f);
        }
        else if (moveVector.x < 0) //Esquerda
        {
            GetComponent<SpriteRenderer>().sprite = spriteVanLeft;
            GetComponent<BoxCollider2D>().size = new Vector2(2.7f, 1.14f);
        }

    }

    //Movimenta��o do player
    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }
}*/
