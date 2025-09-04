using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int points = 0;
    public int life = 3;
    public float timeLeft = 60f;
    public bool hasKey = false;

    [Header("UI")]
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI keyText;
    public GameObject winPanel;

    public GameObject obstacle;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Update()
    {
      
        timeLeft -= Time.deltaTime;
        timeText.text = "Tiempo: " + Mathf.Round(timeLeft);

        if (timeLeft <= 0) RestartGame();

        
        lifeText.text = "Vida: " + life;

       
        pointsText.text = "Puntos: " + points;

       
        keyText.text = "Llave: " + (hasKey ? "Sí" : "No");
    }

    public void AddPoint()
    {
        points++;
        if (points >= 10 && obstacle != null)
        {
            Destroy(obstacle);
        }
    }

    public void AddLife(int amount)
    {
        life += amount;
    }

    public void TakeDamage(int amount)
    {
        life -= amount;
        if (life <= 0) RestartGame();
    }

    public void AddTime(float amount)
    {
        timeLeft += amount;
    }

    public void CollectKey()
    {
        hasKey = true;
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f; 
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}