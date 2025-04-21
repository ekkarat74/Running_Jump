using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore()
    {
        UIManager.instance.AddTextScore();
    }
    
    public void AddCoid()
    {
        UIManager.instance.AddTextCoin();
    }
}
