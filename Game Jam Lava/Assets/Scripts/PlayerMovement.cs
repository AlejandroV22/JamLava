
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontalMovement;

    public float jumpForce = 10f;      // Fuerza inicial del salto
    public float fallMultiplier = 2f; // Multiplicador de la gravedad al caer
    public float lowJumpMultiplier = 1.5f; // Multiplicador de la gravedad para saltos bajos
    private Rigidbody2D rb;           // Referencia al componente Rigidbody2D

    public float horizontalMovementSpeed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Obtener el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMovement = Input.GetAxisRaw("Horizontal");

        Move(horizontalMovement);

        Jump();

    }

    void Move(float horizontalMovement)
    {

        transform.position += new Vector3(horizontalMovement, 0, 0) * horizontalMovementSpeed * Time.deltaTime;


    }

    void Jump()
    {

        // Detectar si se presiona la tecla Espacio para saltar
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.001f)
        {
            Debug.Log("pressed and velocity low");
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        // Ajustar la gravedad al caer
        if (rb.linearVelocity.y < 0)
        {
            // Incrementar la gravedad al caer
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            // Hacer que los saltos bajos sean más controlables
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }
}
