using UnityEngine;

public class LavaActivator : MonoBehaviour
{
    public LavaBehaviour lava; // Referencia al script de la lava
    public CountdownTimer countdownTimer; // Referencia al script del contador

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lava.ActivateLava(); // Activar la lava
            countdownTimer.StartCountdown(); // Iniciar el contador
            Debug.Log("¡Trigger activado! La lava comienza a moverse y el contador empieza.");
            Destroy(gameObject); // Eliminar el activador después de usarlo
        }
    }
}
    