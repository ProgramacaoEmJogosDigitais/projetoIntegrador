using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O objeto que a câmera seguirá
    public float smoothSpeed = 0.125f; // Velocidade de suavização da movimentação da câmera
    public Vector3 offset; // A distância entre a câmera e o objeto

    private Vector3 initialPosition; // A posição inicial da câmera antes de começar a seguir o objeto

    void Start()
    {
        // Salva a posição inicial da câmera
        initialPosition = transform.position;

        // Move a câmera para a posição inicial (fora do objeto)
        transform.position = initialPosition + new Vector3(0f, 0f, -10f); // Você pode ajustar o valor Z conforme necessário
    }

    void FixedUpdate()
    {
        // Calcula a posição desejada da câmera
        Vector3 desiredPosition = target.position + offset;

        // Move suavemente a câmera para a posição desejada usando a função Lerp
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualiza a posição da câmera
        transform.position = smoothedPosition;
    }

    // Método para reiniciar a posição da câmera para a posição inicial
    public void ResetCameraPosition()
    {
        transform.position = initialPosition + new Vector3(0f, 0f, -10f); // Você pode ajustar o valor Z conforme necessário
    }
}
