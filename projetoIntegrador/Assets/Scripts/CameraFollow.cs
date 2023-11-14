using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O objeto que a c�mera seguir�
    public float smoothSpeed = 0.125f; // Velocidade de suaviza��o da movimenta��o da c�mera
    public Vector3 offset; // A dist�ncia entre a c�mera e o objeto

    private Vector3 initialPosition; // A posi��o inicial da c�mera antes de come�ar a seguir o objeto

    void Start()
    {
        // Salva a posi��o inicial da c�mera
        initialPosition = transform.position;

        // Move a c�mera para a posi��o inicial (fora do objeto)
        transform.position = initialPosition + new Vector3(0f, 0f, -10f); // Voc� pode ajustar o valor Z conforme necess�rio
    }

    void FixedUpdate()
    {
        // Calcula a posi��o desejada da c�mera
        Vector3 desiredPosition = target.position + offset;

        // Move suavemente a c�mera para a posi��o desejada usando a fun��o Lerp
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualiza a posi��o da c�mera
        transform.position = smoothedPosition;
    }

    // M�todo para reiniciar a posi��o da c�mera para a posi��o inicial
    public void ResetCameraPosition()
    {
        transform.position = initialPosition + new Vector3(0f, 0f, -10f); // Voc� pode ajustar o valor Z conforme necess�rio
    }
}
