using UnityEngine;

public class Vuelo : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] 
    private float moveSpeed = 6f;

    [Header("Impulso de vuelo")]
    [SerializeField]
    private float jumpForce = 8f;

    private Rigidbody2D rb;
    private float inputX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        inputX = Input.GetAxisRaw("Horizontal");

       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
       
        rb.linearVelocity = new Vector2(inputX * moveSpeed, rb.linearVelocity.y);
    }
}
