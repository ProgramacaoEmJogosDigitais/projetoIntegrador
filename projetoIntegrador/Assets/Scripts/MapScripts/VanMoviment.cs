using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VanMoviment : MonoBehaviour
{
    public CustomImput input = null;
    public float moveSpeed;
    public Vector2 moveVector = Vector2.zero;
    public Sprite spriteVanUpAndDown;
    public Sprite spriteVanRight;
    public Sprite spriteVanLeft;

    public GameObject wheelLeft;
    public GameObject wheelRight;

    public Transform posInitial;
    public bool isMoving = false;

    private float idleTime = 0f;
    private bool isArrowDisplayed = false;
    private bool isObjectSpawned = false;

    public GameObject arrowPrefab;
    private GameObject arrowObject;

    public List<GameObject> randomObjects;
    private GameObject currentRandomObject;

    private void Awake()
    {
        input = new CustomImput();
    }

    private void Start()
    {
        transform.position = posInitial.position;
        DisplayArrow();
        StartCoroutine(RandomObjectSpawner());
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Moviment.performed += SetMovement;
        input.Player.Moviment.canceled += SetMovement;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Moviment.performed -= SetMovement;
        input.Player.Moviment.canceled -= SetMovement;
    }

    public void SetMovement(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if (isMoving)
        {
            idleTime = 0f;

            if (isArrowDisplayed)
            {
                DestroyArrow();
            }

            if (!isObjectSpawned)
            {
                SpawnRandomObject();
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

        MoveVan();
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

    private void MoveVan()
    {
        
        transform.Translate(new Vector3(moveVector.x, moveVector.y, 0) * moveSpeed * Time.deltaTime);
    }

    private void SpawnRandomObject()
    {
        if (randomObjects.Count > 0)
        {
            GameObject randomPrefab = randomObjects[Random.Range(0, randomObjects.Count)];

            
            Vector3 spawnPosition = transform.position + new Vector3(0, 2, 0);

           
            currentRandomObject = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
            isObjectSpawned = true;
            currentRandomObject.transform.parent = transform;
            currentRandomObject.transform.rotation = Quaternion.identity;

            
            Destroy(currentRandomObject, 5f);
        }
    }


    private IEnumerator RandomObjectSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (isObjectSpawned && currentRandomObject == null)
            {
                isObjectSpawned = false;
            }
        }
    }
}
