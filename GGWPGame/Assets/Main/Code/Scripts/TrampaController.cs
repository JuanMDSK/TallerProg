using UnityEngine;

public class TrampaController : MonoBehaviour
{
    public int damage = 1; // cuánta vida quita la trampa

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Resta vida al jugador
            GameManager.instance.TakeDamage(damage);
        }
    }
}