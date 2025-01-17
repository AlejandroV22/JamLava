using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMovement;
    private Rigidbody2D rb;

    public float jumpForce = 10f;      // Fuerza inicial del salto
    public float fallMultiplier = 2f; // Multiplicador de la gravedad al caer
    public float lowJumpMultiplier = 1.5f; // Multiplicador de la gravedad para saltos bajos
    public float horizontalMovementSpeed = 4f;

    public LayerMask groundLayer;  // Capa para identificar objetos del suelo
    public Transform groundCheck; // Punto desde el cual verificamos contacto con el suelo
    public float groundCheckRadius = 0.2f; // Radio para detectar el suelo

    private bool isGrounded;       // Indica si el jugador está tocando el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        Move(horizontalMovement);

        CheckIfGrounded(); // Verificar si está en contacto con el suelo
        Jump();
    }

    void Move(float horizontalMovement)
    {
        transform.position += new Vector3(horizontalMovement, 0, 0) * horizontalMovementSpeed * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded()
    {
        // Verificar si el círculo alrededor de groundCheck detecta objetos en la capa del suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        // Dibuja un círculo en la escena para visualizar el área de detección de suelo
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
