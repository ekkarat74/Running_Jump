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

        HideAllPanels();
    }
    
    private void HideAllPanels()
    {
        gameOverPanel.SetActive(false);
    }

    public void AddTextScore()
    {
        score++;
        scoreText.text = score.ToString();
        switch (score)
        {
            case 0:
                Spawner.maxTime = 2.2f;
                Move_Obstacle.speed = 2f;
                Move_Coin.speed = 2f;
                break;
            case 8:
                Spawner.maxTime = 2;
                Move_Obstacle.speed = 3f;
                Move_Coin.speed = 3f;
                break;
            case 16:
                Spawner.maxTime = 1.8f;
                Move_Obstacle.speed = 4f;
                Move_Coin.speed = 4f;
                break;
            case 24:
                Spawner.maxTime = 1.6f;
                Move_Obstacle.speed = 5f;
                Move_Coin.speed = 5f;
                break;
            case 32:
                Spawner.maxTime = 1.4f;
                Move_Obstacle.speed = 6f;
                Move_Coin.speed = 6f;
                break;
        }
    }
    
    public void AddTextCoin()
    {
        coin++;
        CoinText.text = coin.ToString();
    }
    
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        score = 0;
        coin = 0;
        
        Spawner.maxTime = 2.2f;
        Move_Obstacle.speed = 2;
        Move_Coin.speed = 2;
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
