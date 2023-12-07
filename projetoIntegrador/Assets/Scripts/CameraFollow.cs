using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;

        transform.position = initialPosition + new Vector3(0f, 0f, -10f);
    }

    void FixedUpdate()
    {

        Vector3 desiredPosition = target.position + offset;


        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);


        transform.position = smoothedPosition;
    }


    public void ResetCameraPosition()
    {
        transform.position = initialPosition + new Vector3(0f, 0f, -10f);
    }
}
