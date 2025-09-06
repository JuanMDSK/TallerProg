using UnityEngine;

public class HuesoPuntos : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddPoint();
            Destroy(gameObject); // Desaparece al recogerlo
        }
    }
}

