using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI CoinText;
    public GameObject gameOverPanel;
    public GameObject StartGamePanel;
    
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
            StartGamePanel.SetActive(false);
        }
        
    }

    public void AddTextScore()
    {
        score++;
        scoreText.text = score.ToString();
        switch (score)
        {
            case 0:
                Spawner.TimeSpawnObstacle = 2.2f;
                Spawner.TimeSpawnEnemy = 2.2f;
                MoveObject.speed = 2f;
                break;
            case 8:
                Spawner.TimeSpawnObstacle = 2;
                Spawner.TimeSpawnEnemy = 2f;
                MoveObject.speed = 3f;
                break;
            case 16:
                Spawner.TimeSpawnObstacle = 1.8f;
                Spawner.TimeSpawnEnemy = 1.8f;
                MoveObject.speed = 4f;
                break;
            case 24:
                Spawner.TimeSpawnObstacle = 1.6f;
                Spawner.TimeSpawnEnemy = 1.6f;
                MoveObject.speed = 5f;
                break;
            case 32:
                Spawner.TimeSpawnObstacle = 1.4f;
                Spawner.TimeSpawnEnemy = 1.4f;
                MoveObject.speed = 6f;
                break;
        }
    }
    
    public void AddTextCoin()
    {
        coin++;
        CoinText.text = coin.ToString();
    }
    
    public void ShowStartGamePanel()
    {
        StartGamePanel.SetActive(true);
    }
    
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        StartGamePanel.SetActive(false);
        Time.timeScale = 1f;
        hasStartGame = true;
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
