using UnityEngine;

public class LlaveController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CollectKey();
            Destroy(gameObject); // la llave desaparece al recogerla
        }
    }
}
