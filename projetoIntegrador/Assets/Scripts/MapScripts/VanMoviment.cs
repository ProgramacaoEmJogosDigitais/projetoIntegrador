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
    public Sprite spriteVanUpAndDown;
    public Sprite spriteVanRight;
    public Sprite spriteVanLeft;

    public GameObject wheelLeft;
    public GameObject wheelRight;

    public Transform posInitial;
    public bool isMoving = false;
    public GameObject arrowPrefab;
    public MapManager mapManager;

    private float idleTime = 0f;
    private bool isArrowDisplayed = false;
    private GameObject arrowObject;

    private void Awake()
    {
        input = new CustomImput();
    }

    private void Start()
    {
        transform.position = posInitial.position;
        DisplayArrow();
        if (!mapManager.instructions)
        {
            StartCoroutine(Collider());
        }
    }
    public IEnumerator Collider()
    {
        yield return new WaitForSeconds(1.2f);
        GetComponent<BoxCollider2D>().enabled = true;
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

    void Update()
    {
        if (isMoving)
        {
            idleTime = 0f;
            if (isArrowDisplayed)
            {
                DestroyArrow();
            }
        }
        else
        {
            idleTime += Time.deltaTime;
            if (idleTime >= 2.5f && !isArrowDisplayed)
            {
                DisplayArrow();
            }
        }
    }

    private void DisplayArrow()
    {
        if (arrowPrefab != null)
        {
            arrowObject = Instantiate(arrowPrefab, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            isArrowDisplayed = true;
        }
    }

    private void DestroyArrow()
    {
        if (arrowObject != null)
        {
            Destroy(arrowObject);
            isArrowDisplayed = false;
        }
    }
}
