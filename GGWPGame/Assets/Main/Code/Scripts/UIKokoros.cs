using UnityEngine;
using UnityEngine.UI;

public class UIKokoros : MonoBehaviour
{
    public static UIKokoros instance;

    [Header("Corazones UI")]
    [SerializeField] private Image[] hearts; // Arrastras 5 im�genes de corazones

    void Awake()
    {
        if (instance == null) instance = this;
    }

    // Actualiza los corazones
    public void UpdateHeartsUI(int life)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < life)
                hearts[i].enabled = true;  // Activo los corazones hasta el n�mero de vida
            else
                hearts[i].enabled = false; // Los dem�s se apagan
        }
    }
}

