using UnityEngine;

public class PuertaController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.instance.hasKey)
        {
            GameManager.instance.WinGame();
        }
    }
}
