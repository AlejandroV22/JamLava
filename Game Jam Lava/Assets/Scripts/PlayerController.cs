using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento horizontal
    public float jumpForce = 10f; // Fuerza del salto

    private Rigidbody2D rb; // Referencia al Rigidbody2D
    private bool isGrounded = true; // Indica si el jugador está en el suelo

    void Start()
    {
        // Obtener el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento lateral
        float moveInput = Input.GetAxis("Horizontal"); // Toma los valores de A y D
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Salto
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Solo salta si está en el suelo
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar si el jugador toca el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
