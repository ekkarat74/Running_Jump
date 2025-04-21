using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static float maxTime = 2.2f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject Obstacle;
    
    [SerializeField] private float Destoryobstacle = 10f;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            SpawnObstacle();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    void SpawnObstacle()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject obstacle = Instantiate(Obstacle, spawnPosition, Quaternion.identity);
        
        Destroy(obstacle, Destoryobstacle);
    }
}
