using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Time Spawner")]
    public static float TimeSpawnObstacle = 2.2f;
    public static float TimeSpawnEnemy = 2f;
    
    [Header("Settings Spawner")]
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private float DestoryObject = 10f;
    
    [Header("Game Object Spawner")]
    [SerializeField] private GameObject Obstacle;
    [SerializeField] private GameObject Enemy;

    private float obstacletimer;
    private float enemytimer;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        obstacletimer += Time.deltaTime;
        enemytimer += Time.deltaTime;
        
        if (obstacletimer > TimeSpawnObstacle)
        {
            SpawnObstacle();
            obstacletimer = 0;
        }

        if (enemytimer > TimeSpawnEnemy)
        {
            SpawnEnemy();
            enemytimer = 0;
        }
    }

    void SpawnObstacle()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject obstacle = Instantiate(Obstacle, spawnPosition, Quaternion.identity);
        
        Destroy(obstacle, DestoryObject);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange), 0);
        GameObject enemy = Instantiate(Enemy, spawnPos, Quaternion.identity);
        Destroy(enemy, DestoryObject);
    }
}
