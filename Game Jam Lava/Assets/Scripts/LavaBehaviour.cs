using UnityEngine;
using System.Collections;

public class LavaBehaviour : MonoBehaviour
{
    // Velocidad de movimiento vertical de la lava
    public float speed = 2f;
    public float slowDownDuration = 2f; // Duración del efecto de ralentización
    public float slowDownFactor = 0.5f; // Factor por el cual reducir la velocidad
    private float originalSpeed; // Para guardar la velocidad original

     void Start()
    {
        originalSpeed = speed; // Guardar la velocidad inicial
    }
    void Update()
    {
    transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detectar si el objeto que entra en la lava es el jugador
        if (collision.CompareTag("Player"))
        {
            // Aquí puedes manejar lo que pasa cuando el jugador toca la lava

            // Reiniciar la escena
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("La lava tocó un enemigo. Velocidad reducida!");
            StartCoroutine(SlowDown());
        }
    }
    IEnumerator SlowDown()
    {
        // Reducir la velocidad
        speed /= slowDownFactor;

        // Esperar la duración del efecto de ralentización
        yield return new WaitForSeconds(slowDownDuration);

        // Restaurar la velocidad original
        speed = originalSpeed;
        Debug.Log("La velocidad de la lava volvió a la normalidad.");
    }
}
