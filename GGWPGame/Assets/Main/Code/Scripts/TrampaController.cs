using UnityEngine;

public class TrampaController : MonoBehaviour
{
    [SerializeField] 
    private int damage = 1; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            GameManager.instance.TakeDamage(damage);
        }
    }
}
