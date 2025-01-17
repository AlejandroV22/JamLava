using UnityEngine;

public class LavaBehaviour : MonoBehaviour
{
    public float speed = 2f; // Velocidad inicial de la lava
    public float maxSpeed = 10f; // Velocidad máxima que la lava puede alcanzar
    public float speedIncreaseRate = 0.1f; // Velocidad de incremento por segundo
    public float instantKillSpeed = 50f; // Velocidad extrema para el InstantKill

    private float currentSpeed; // Velocidad actual de la lava
    private bool isActivated = false; // Flag para activar/desactivar el movimiento de la lava
    private bool isInstantKillActive = false; // Si la lava está en modo InstantKill

    void Start()
    {
        currentSpeed = speed; // Establecer la velocidad inicial
    }

    void Update()
    {
        if (!isActivated) return; // No hacer nada si la lava no está activada

        // Incrementar la velocidad de la lava hasta el máximo permitido (si no está en modo InstantKill)
        if (!isInstantKillActive)
        {
            currentSpeed = Mathf.Min(currentSpeed + speedIncreaseRate * Time.deltaTime, maxSpeed);
        }

        // Mover la lava hacia arriba
        transform.position += Vector3.up * currentSpeed * Time.deltaTime;
    }

    public void ActivateLava()
    {
        // Activa el movimiento de la lava
        isActivated = true;
        Debug.Log("¡La lava ha sido activada!");
    }

    public void InstantKill()
    {
        // Activar el modo InstantKill aumentando drásticamente la velocidad
        isInstantKillActive = true;
        currentSpeed = instantKillSpeed;
        Debug.Log("¡Modo InstantKill activado! La lava sube a gran velocidad.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador tocó la lava!");
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
