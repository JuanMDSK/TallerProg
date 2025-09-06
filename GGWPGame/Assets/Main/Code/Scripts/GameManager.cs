using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Valores del juego")]
    public int points = 0;       // Puntos por huesos
    public int life = 3;         // Vida inicial
    public float timeLeft = 60f; // Tiempo inicial en segundos

    [Header("UI")]
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI timeText;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Update()
    {
        // --- Tiempo ---
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            RestartGame();
        }

        // --- Actualizar UI ---
        if (pointsText != null)
            pointsText.text = "Puntos: " + points;

        if (lifeText != null)
            lifeText.text = "Vida: " + life;

        if (timeText != null)
            timeText.text = "Tiempo: " + Mathf.Round(timeLeft);
    }

    // --- Métodos públicos que llaman los ítems ---
    public void AddPoint()
    {
        points++;

        points++;

        // Si ya llegaste a 10 o más puntos, el obstáculo desaparece
        if (points >= 10 && Obstaculo != null)
        {
            Destroy(Obstaculo);
        }
    }

    public void AddLife(int amount)
    {
        life += amount;

    }

    public void TakeDamage(int amount)
    {
        life -= amount;
        if (life <= 0)
        {
            RestartGame();
        }
    }

    public void AddTime(float amount)
    {
        timeLeft += amount;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public GameObject Obstaculo; // arrastra aquí el obstáculo desde la escena

    [Header("Llave y Puerta")]
    public bool hasKey = false;        // estado de la llave
    public GameObject door;            // arrastra aquí la puerta
    public GameObject winPanel;        // panel de victoria (UI)

    public void CollectKey()
    {
        hasKey = true;

        // Mostrar en consola (opcional)
        Debug.Log("¡Has recogido la llave!");

        // Activar la puerta cuando consigues la llave
        if (door != null)
            door.SetActive(true);
    }

    public void WinGame()
    {
        if (winPanel != null)
            winPanel.SetActive(true);

        Time.timeScale = 0f; // pausa el juego
        Debug.Log("¡GANASTE!");
    }



}
