using UnityEngine;

public class MuslitoTiempo : MonoBehaviour
{
    [SerializeField]
    private float amount = 5f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddTime(amount);
            Destroy(gameObject);
        }
    }
}

