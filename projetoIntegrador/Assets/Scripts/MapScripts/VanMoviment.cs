using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class VanMoviment : MonoBehaviour
{
    public CustomImput input = null; // Vari�vel para receber o input do jogador
    public float moveSpeed;
    public Vector2 moveVector = Vector2.zero;
    public Sprite spriteVanUpAndDown;
    public Sprite spriteVanRight;
    public Sprite spriteVanLeft;

    public GameObject wheelLeft;
    public GameObject wheelRight;
    public GameObject cameraMain;
    public Transform posInitial;
    public bool isMoving = false;


    public List<GameObject> arrowPrefabs = new List<GameObject>();
    private List<GameObject> arrowObjects = new List<GameObject>();
    GameObject arrowObject;


    private void Awake()
    {
        input = new CustomImput();
    }

    private void Start()
    {
        transform.position = posInitial.position;
        StartCoroutine(CameraAnimator());
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
        if (arrowObject != null)
        {
            if (moveVector.x == 0 && moveVector.y > 0)
            {
            
            }
            else if (moveVector.x == 0 && moveVector.y < 0)
            {
             
            }
            else if (moveVector.x < 0 && moveVector.y == 0)
            {
              
            }
            else if (moveVector.x > 0 && moveVector.y == 0)
            {
              
            }
            Vector3 offset = new Vector3(0.5f, 1.1f, 0f);
            arrowObject.transform.position = gameObject.transform.position + offset;
        }


        if (arrowObjects.Count >= arrowPrefabs.Count)
        {
            foreach (GameObject arrowObject in arrowObjects)
            {
                Destroy(arrowObject);
            }
            arrowObjects.Clear();
        }
    }
    IEnumerator CameraAnimator()
    {
        yield return new WaitForSeconds(13.50f);
        cameraMain.GetComponent<Animator>().enabled = false;

    }


    IEnumerator SpawnArrowRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(6f);
            SpawnRandomArrow();
            StartCoroutine(DestroyArrowRoutine());
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
    }

    private void SpawnRandomArrow()
    {
        if (arrowPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, arrowPrefabs.Count);
            GameObject selectedArrowPrefab = arrowPrefabs[randomIndex];
            arrowObject = Instantiate(selectedArrowPrefab, transform.position + new Vector3(0, 2, 0), Quaternion.identity);

            //arrowObject.transform.parent = transform;

            arrowObjects.Add(arrowObject);
        }
    }
}