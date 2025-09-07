using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    float horizontalInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
       
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }
}

