using UnityEngine;

public class MuslitoTiempo : MonoBehaviour
{
    public float amount = 5f; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddTime(amount);
            Destroy(gameObject);
        }
    }
}

