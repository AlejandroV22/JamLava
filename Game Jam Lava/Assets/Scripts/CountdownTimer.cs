using UnityEngine;
using TMPro; // Para TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    public float startTime = 10f; // Tiempo inicial
    private float timeRemaining; // Tiempo restante
    private bool isCountingDown = false; // ¿Está corriendo el contador?

    public TextMeshProUGUI countdownText; // Para mostrar el texto
    public LavaBehaviour lava; // Referencia al script de LavaBehaviour

    void Start()
    {
        timeRemaining = startTime;
        UpdateCountdownText();
    }

    void Update()
    {
        if (isCountingDown)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                // Llamamos a InstantKill cuando el contador llegue a 0
                lava.InstantKill();  
                Debug.Log("¡Tiempo agotado! La lava sube instantáneamente.");
            }

            UpdateCountdownText();
        }
    }

    void UpdateCountdownText()
    {
        // Actualiza el texto con el tiempo restante
        countdownText.text = Mathf.Ceil(timeRemaining).ToString();
    }

    // Método para iniciar el contador
    public void StartCountdown()
    {
        isCountingDown = true;
    }
}
