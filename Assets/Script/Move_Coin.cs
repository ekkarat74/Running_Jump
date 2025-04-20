using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Coin : MonoBehaviour
{
    [SerializeField] private float speed;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
