using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public static float speed = 2f;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
