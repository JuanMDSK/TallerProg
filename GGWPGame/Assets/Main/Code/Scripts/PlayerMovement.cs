using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;                 // velocidad horizontal
    public float jumpForce = 8f;                 // impulso vertical al saltar
    public float jumpHorizontalMultiplier = 0.6f; // cu�nto del input horizontal se aplica como impulso en X al saltar

    [Header("Detecci�n de suelo")]
    public Transform groundCheck;                // punto (hijo) desde donde verificamos si est� en el suelo
    public float groundCheckRadius = 0.12f;      // radio del overlap para chequear el suelo
    public LayerMask groundLayer;                // layers que cuentan como suelo

    [Header("Opcionales")]
    public Animator animator;                    // si tienes animaciones
    public SpriteRenderer spriteRenderer;        // para voltear sprite seg�n direcci�n

    Rigidbody2D rb;
    float horizontalInput;
    bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // Recomiendo en el Rigidbody2D: Freeze Rotation Z (para que no rote)
    }

    void Update()
    {
        // 1) Obtenemos la entrada horizontal (-1, 0, +1 con GetAxisRaw)
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // 2) Flip del sprite (opcional)
        if (spriteRenderer != null && horizontalInput != 0f)
            spriteRenderer.flipX = horizontalInput < 0f;

        // 3) Saltar: cuando se presiona Space y estamos en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Impulso que incluye componente X basada en la direcci�n actual
            Vector2 jumpImpulse = new Vector2(horizontalInput * moveSpeed * jumpHorizontalMultiplier, jumpForce);
            rb.AddForce(jumpImpulse, ForceMode2D.Impulse);
        }

        // 4) Actualizar par�metros de animator si existe
        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
            animator.SetBool("Grounded", isGrounded);
        }
    }

    void FixedUpdate()
    {
        // 5) Chequeo de suelo
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        // 6) Movimiento lateral (establecemos velocidad X directamente para mayor control)
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    // Visual ayuda en editor para ver el groundCheck
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    // Opcional: ejemplo simple de detecci�n de pickups/trampas (recomiendo dejar la l�gica en cada �tem)
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Trap"))
    //        GameManager.instance.TakeDamage(1);
    //    else if (other.CompareTag("Bone"))
    //    {
    //        GameManager.instance.AddPoint();
    //        Destroy(other.gameObject);
    //    }
    //}
}
