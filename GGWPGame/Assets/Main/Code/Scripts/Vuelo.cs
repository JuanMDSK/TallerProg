using UnityEngine;

public class Vuelo : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 6f;

    [Header("Impulso de vuelo")]
    public float JumpForce = 8f;

    Rigidbody2D rb;

    [SerializeField]
    float inputX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    [System.Obsolete]
    void Update()
    {
        
        inputX = Input.GetAxisRaw("Horizontal");

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        
        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);
    }
}