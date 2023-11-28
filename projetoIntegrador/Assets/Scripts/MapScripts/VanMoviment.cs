using System.Collections;
using System.Collections.Generic;
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

    
    private List<GameObject> arrowObjects = new List<GameObject>();
    private bool canSpawn = true;
    public List<GameObject> arrowPrefabs = new List<GameObject>();

    private void Awake()
    {
        input = new CustomImput();
    }

    private void Start()
    {
        transform.position = posInitial.position;
        StartCoroutine(SpawnArrowRoutine());
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

    void Update()
    {


        if (arrowObjects.Count > 0)
        {
            foreach (GameObject arrowObject in arrowObjects)
            {
                Destroy(arrowObject);
            }
            arrowObjects.Clear();
        }


    }

    IEnumerator SpawnArrowRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            if (canSpawn)
            {
                SpawnRandomArrow();
                canSpawn = false;
                StartCoroutine(DestroyArrowRoutine());
            }
        }
    }

    IEnumerator DestroyArrowRoutine()
    {
        yield return new WaitForSeconds(5f);
        if (arrowObjects.Count > 0)
        {
            foreach (GameObject arrowObject in arrowObjects)
            {
                Destroy(arrowObject);
            }
            arrowObjects.Clear();
        }
        canSpawn = true;
    }

    private void SpawnRandomArrow()
    {
        if (arrowPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, arrowPrefabs.Count);
            GameObject selectedArrowPrefab = arrowPrefabs[randomIndex];
            GameObject arrowObject = Instantiate(selectedArrowPrefab, transform.position + new Vector3(0, 2, 0), Quaternion.identity);

            arrowObject.transform.parent = transform;

            arrowObjects.Add(arrowObject);
        }
    }
}
