using UnityEngine;

public class GoalPlatform : MonoBehaviour
{
    public GameObject victoryMessageUI; // Referencia al mensaje de victoria en la UI

    private bool gameWon = false; // Para evitar multiples activaciones

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar si el jugador llegó a la meta
        if (collision.gameObject.CompareTag("Player") && !gameWon)
        {
            gameWon = true; // Asegurar que solo se ejecute una vez
            Victory();
        }
    }

    void Victory()
    {
        // Mostrar el mensaje de victoria
        if (victoryMessageUI != null)
        {
            victoryMessageUI.SetActive(true);
        }

        // Congelar el tiempo
        Time.timeScale = 0f;

        Debug.Log("¡Victoria! El jugador alcanzó la meta.");
    }
}
