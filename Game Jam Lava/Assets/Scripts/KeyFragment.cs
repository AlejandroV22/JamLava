using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFragment : MonoBehaviour
{
        // Amplitud del movimiento (distancia desde el punto medio hasta los extremos)
    public float amplitude = 2f;

    // Frecuencia del movimiento (número de ciclos por segundo)
    public float frequency = 1f;

    // Punto medio en el eje Y (alrededor del cual oscilará el objeto)
    private float yOffset = 0f;

    // Tiempo acumulado para calcular la posición
    private float time;

    void Start()
    {
        yOffset = transform.position.y;
    }

    void Update()
    {
        Oscilate();
        
    }

    void Oscilate()
    {

        // Incrementar el tiempo con la duración del último fotograma
        time += Time.deltaTime;

        // Calcular la posición Y usando una función sinusoidal
        float newY = yOffset + Mathf.Sin(time * frequency * Mathf.PI * 2) * amplitude;

        // Aplicar la nueva posición al objeto
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

    }
}