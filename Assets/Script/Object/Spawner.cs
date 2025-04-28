using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Time Spawner")]
    public static float TimeSpawnObstacle = 2.2f;
    public static float TimeSpawnEnemy = 2f;
    
    [Header("Settings Spawner")]
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private float destroyObject = 10f;
    
    [Header("Game Object Spawner")]
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject enemy;

    private float obstacleTimer;
    private float enemyTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        obstacleTimer += Time.deltaTime;
        enemyTimer += Time.deltaTime;
        
        if (obstacleTimer > TimeSpawnObstacle)
        {
            SpawnObstacle();
            obstacleTimer = 0;
        }

        if (enemyTimer > TimeSpawnEnemy)
        {
            SpawnEnemy();
            enemyTimer = 0;
        }
    }

    void SpawnObstacle()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject obstacle = Instantiate(this.obstacle, spawnPosition, Quaternion.identity);

        Destroy(obstacle, destroyObject);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange), 0);
        GameObject enemy = Instantiate(this.enemy, spawnPos, Quaternion.identity);
        Destroy(enemy, destroyObject);
    }
}
