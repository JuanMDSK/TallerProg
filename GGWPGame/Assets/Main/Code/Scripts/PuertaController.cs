using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.instance.hasKey)
        {
            SceneManager.LoadScene(2);
        }
    }
}
