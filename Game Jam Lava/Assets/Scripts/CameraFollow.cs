using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referencia al Transform del jugador
    public Vector3 offset = new Vector3(0f, 2f, -10f); // Desplazamiento de la cámara respecto al jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado

    public bool useBounds = true; // Activar o desactivar los límites
    public Vector2 minBounds; // Límites mínimos de la cámara
    public Vector2 maxBounds; // Límites máximos de la cámara

    void LateUpdate()
    {
        if (player == null) return; // Asegúrate de que hay un jugador asignado

        // Posición deseada de la cámara con el offset
        Vector3 desiredPosition = player.position + offset;

        // Si los límites están activados, ajusta la posición deseada
        if (useBounds)
        {
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);
        }

        // Suavizar el movimiento de la cámara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizar la posición de la cámara
        transform.position = smoothedPosition;
    }
}
