using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10f; // Tiempo inicial del contador
    public TextMeshProUGUI countdownText;
    public LavaBehaviour lava; // Referencia al script de la lava

    private bool countdownEnded = false;

    void Update()
    {
        if (countdownTime > 0)
        {
            // Reducir el tiempo restante
            countdownTime -= Time.deltaTime;

            // Actualizar el texto del temporizador en pantalla
            countdownText.text = Mathf.Ceil(countdownTime).ToString();
        }
        else if (!countdownEnded)
        {
            // Detener el contador y subir la lava
            countdownEnded = true;
            TriggerLavaRise();
        }
    }

    void TriggerLavaRise()
    {
        // Hacer que la lava suba rápidamente
        lava.InstantKill();
        Debug.Log("El tiempo se acabó. ¡La lava sube instantáneamente!");
    }
}

