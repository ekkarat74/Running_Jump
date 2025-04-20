
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;
    
    [SerializeField] private TextMeshProUGUI currentscoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private int score;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        currentscoreText.text = score.ToString();
        
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScene();
    }

    void UpdateHighScene()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }

    public void UpdateScore()
    {
        score++;
        currentscoreText.text = score.ToString();
        UpdateHighScene();
    }
}