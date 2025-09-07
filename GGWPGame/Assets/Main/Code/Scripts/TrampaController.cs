using UnityEngine;

public class TrampaController : MonoBehaviour
{
    public int damage = 1; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            GameManager.instance.TakeDamage(damage);
        }
    }
}