using UnityEngine;

public class MuslitoVida : MonoBehaviour
{
    public int amount = 1; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddLife(amount);
            Destroy(gameObject);
        }
    }
}

