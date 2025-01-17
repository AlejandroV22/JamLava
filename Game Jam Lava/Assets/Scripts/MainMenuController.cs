using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class MainMenuController : MonoBehaviour
{
    // Este método se llamará cuando el jugador presione cualquier botón
    public void StartGame()
    {
        // Cargar la escena del juego. 
        SceneManager.LoadScene("Level1"); 
    }

    void Update()
    {
        // Detectar cualquier pulsación de tecla o clic para iniciar el juego
        if (Input.anyKeyDown) // Detecta cualquier tecla
        {
            StartGame();
        }
    }
}
