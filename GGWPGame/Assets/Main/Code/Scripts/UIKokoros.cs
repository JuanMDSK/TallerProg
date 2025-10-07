using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIKokoros : MonoBehaviour
{
    public static UIKokoros instance; 

    [Header("Corazones UI")]
    [SerializeField] private Image[] hearts; 

    [Header("Texto UI")]
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI timeText;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    
    public void UpdateHeartsUI(int life)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            
            hearts[i].enabled = i < life;
        }
    }

    
    public void UpdatePointsUI(int points)
    {
        if (pointsText != null)
            pointsText.text = "Puntos: " + points;
    }

   
    public void UpdateTimeUI(float timeLeft)
    {
        if (timeText != null)
            timeText.text = "Tiempo: " + Mathf.Round(timeLeft);
    }
}


