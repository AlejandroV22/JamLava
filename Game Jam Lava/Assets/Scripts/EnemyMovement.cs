using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidad del enemigo
    public Transform pointA; // Punto inicial
    public Transform pointB; // Punto final

    private Transform currentTarget; // Objetivo actual

    void Start()
    {
        // Comenzamos moviéndonos hacia el punto A
        currentTarget = pointB;
    }

    void Update()
{
    // Mover el enemigo hacia el objetivo actual
    transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

    // Cambiar la dirección del sprite
    if (currentTarget.position.x < transform.position.x)
        transform.localScale = new Vector3(-1, 1, 1); // Mirar a la izquierda
    else
        transform.localScale = new Vector3(1, 1, 1); // Mirar a la derecha

    // Cambiar de dirección al llegar al objetivo
    if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
    {
        currentTarget = (currentTarget == pointA) ? pointB : pointA;
    }
}
private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
        // Reinicia la escena
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}


