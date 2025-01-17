using UnityEngine;

public class LavaBehaviour : MonoBehaviour
{
    // Velocidad de movimiento vertical de la lava
    public float speed = 2f;

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
    }
}
