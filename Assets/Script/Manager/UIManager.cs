using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    public GameObject gameoverPanel;
    public GameObject startgamePanel;
    
    private static bool hasStartGame = false;
    private int coin = 0;
    private int score = 0;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (!hasStartGame)
        {
            Time.timeScale = 0f;
            ShowStartGamePanel();
        }
        else
        {
            Time.timeScale = 1f;
            startgamePanel.SetActive(false);
        }
    }
    
    public void AddTextScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score % 8 == 0)
        {
            Spawner.TimeSpawnObstacle -= 0.1f;
            Spawner.TimeSpawnEnemy -= 0.1f;
            MoveObject.speed += 1f;
        }
    }
    
    public void AddTextCoin()
    {
        coin++;
        coinText.text = coin.ToString();
    }
    
    public void ShowStartGamePanel()
    {
        startgamePanel.SetActive(true);
    }
    
    public void ShowGameOverPanel()
    {
        gameoverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        startgamePanel.SetActive(false);
        Time.timeScale = 1f;
        hasStartGame = true;

        Spawner.TimeSpawnObstacle = 2.2f;
        Spawner.TimeSpawnEnemy = 2.2f;
        MoveObject.speed = 2f;
    }
    
    public void RestartGame()
    {
        score = 0;
        coin = 0;

        Spawner.TimeSpawnObstacle = 2.2f;
        Spawner.TimeSpawnEnemy = 2.2f;
        MoveObject.speed = 2f;

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
