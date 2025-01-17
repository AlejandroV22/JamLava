using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectible : MonoBehaviour
{
    public int totalCollectibles = 5; // Total de objetos coleccionables
    private int collectedCount = 0; // Contador de objetos recolectados

    private int doorIndex = 0;

    public List<GameObject> doorList;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto tiene el tag "Collectible"
        if (collision.CompareTag("Collectible"))
        {
            // Desactivar el coleccionable
            collision.gameObject.SetActive(false);

            // Incrementar el contador
            collectedCount++;

            // Comprobar si se han recolectado todos
            if (collectedCount >= totalCollectibles)
            {
                // Desactivar el Sprite Renderer y el Collider del objeto objetivo
                if (doorList[doorIndex] != null)
                {
                    doorList[doorIndex].GetComponent<SpriteRenderer>().enabled = false;
                    doorList[doorIndex].GetComponent<Collider2D>().enabled = false;

                    collectedCount = 0;
                    doorIndex++;
                }
            }
        }
    }
}
