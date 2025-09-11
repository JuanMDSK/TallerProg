using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
   
    public static GameManager instance;

    [Header("Valores del juego")]
    [SerializeField] 
    private int points = 0;   
    
    [SerializeField] 
    private int life = 3;   
    
    [SerializeField]
    private float timeLeft = 60f;  

    [Header("UI")]
    [SerializeField] 
    private TextMeshProUGUI pointsText;

    [SerializeField] 
    private TextMeshProUGUI lifeText;

    [SerializeField] 
    private TextMeshProUGUI timeText;

    [Header("Obstáculo")]
    [SerializeField]
    private GameObject Obstaculo; 

    [Header("Llave y Puerta")]
    public bool hasKey = false; 
    
    [SerializeField]
    private GameObject door;      

    [SerializeField] 
    private GameObject winPanel; 

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Update()
    {
      
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            RestartGame();
        }

       
        if (pointsText != null)
            pointsText.text = "Puntos: " + points;

        if (lifeText != null)
            lifeText.text = "Vida: " + life;

        if (timeText != null)
            timeText.text = "Tiempo: " + Mathf.Round(timeLeft);
    }

   
    public void AddPoint()
    {
        points++;

        
        if (points >= 5 && Obstaculo != null)
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

    public void CollectKey()
    {
        hasKey = true;
        Debug.Log("¡Has recogido la llave!");

        if (door != null)
            door.SetActive(true);
    }

    public void WinGame()
    {
        if (winPanel != null)
            winPanel.SetActive(true);

        Time.timeScale = 0f; 
        Debug.Log("¡GANASTE!");
    }

    public void EstadoDelJuego(string estado)

    {
        switch (estado)
        {
            case "play":
                Time.timeScale = 1;
            
            case "pause":
                Time.timeScale = 0;







                break;

             




        }
    }
}
