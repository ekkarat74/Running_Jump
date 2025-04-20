using UnityEngine;

public class Move_Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
