using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Valores del juego")]
    [SerializeField] private int points = 0;
    [SerializeField] private int life = 5;
    [SerializeField] private float timeLeft = 60f;

    [Header("UI (referencias del texto)")]
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI timeText;

    [Header("Objetos del juego")]
    [SerializeField] private GameObject obstaculo;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButton;



    [Header("Llave")]
    public bool hasKey = false;

    private string currentState = "Play";

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UIKokoros.instance.UpdateHeartsUI(life);
        UIKokoros.instance.UpdatePointsUI(points);
        UIKokoros.instance.UpdateTimeUI(timeLeft);
        SetGameState("Play");
    }

    void Update()
    {
        if (currentState == "Play")
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                SceneManager.LoadScene(3);
            }

            UIKokoros.instance.UpdateTimeUI(timeLeft);
        }

        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == "Pause") ResumeGame();
            else if (currentState == "Play") PauseGame();
        }

        if (pointsText != null) pointsText.text = "Puntos: " + points;
        if (lifeText != null) lifeText.text = "Vida: " + life;
        if (timeText != null) timeText.text = "Tiempo: " + Mathf.Round(timeLeft);
    }

    
    public void AddPoint()
    {
        points++;
        UIKokoros.instance.UpdatePointsUI(points);

        if (points >= 5 && obstaculo != null)
        {
            Destroy(obstaculo);
        }
    }

 
    public void AddLife(int amount)
    {
        life += amount;
        UIKokoros.instance.UpdateHeartsUI(life);
    }

    public void TakeDamage(int amount)
    {
        life -= amount;
        UIKokoros.instance.UpdateHeartsUI(life);

        if (life <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

   
    public void AddTime(float amount)
    {
        timeLeft += amount;
        UIKokoros.instance.UpdateTimeUI(timeLeft);
    }

  
    public void CollectKey()
    {
        hasKey = true;
        if (door != null) door.SetActive(true);
    }

    public void WinGame()
    {
        SetGameState("Win");
    }

    public void LoseGame()
    {
        SetGameState("Lose");
    }


    public void SetGameState(string state)
    {
        currentState = state;

        switch (state)
        {
            case "Play":
                Time.timeScale = 1;
                if (pausePanel != null) pausePanel.SetActive(false);
                if (winPanel != null) winPanel.SetActive(false);
                if (losePanel != null) losePanel.SetActive(false);
                if (pauseButton != null) pauseButton.SetActive(true);
                break;

            case "Pause":
                Time.timeScale = 0;
                if (pausePanel != null) pausePanel.SetActive(true);
                if (pauseButton != null) pauseButton.SetActive(false); 
                break;


            case "Win":
                Time.timeScale = 0;
                if (winPanel != null) winPanel.SetActive(true);
                if (pauseButton != null) pauseButton.SetActive(false);
                break;

            case "Lose":
                Time.timeScale = 0;
                if (losePanel != null) losePanel.SetActive(true);
                if (pauseButton != null) pauseButton.SetActive(false);
                break;

            case "Exit":
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;    
                break;

            case "Play2":

                SceneManager.LoadScene(1);
                Time.timeScale = 1;
                break;
        }
    }



    public void PauseGame() => SetGameState("Pause");
    public void ResumeGame() => SetGameState("Play");

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        SetGameState("Exit");
    }
}

























