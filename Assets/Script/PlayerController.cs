using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Controller")]
    public float moveSpeed;
    public float jumpForce;
    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;
    
    private Rigidbody2D rb;
    private bool grounded = false;
    private bool isDashing = false;
    private bool isGrounded = false;
    private float dashTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (!isDashing)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        
        //Jump
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); 
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
        // Dash
        if (Input.GetMouseButtonDown(1) && !isDashing)
        {
            StartDash();
        }
        // เช็คสถานะ Dash
        if (isDashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0f)
            {
                EndDash();
            }
        }
    }

    private void StartDash()
    {
        isDashing = true;
        dashTime = dashDuration;
        rb.velocity = new Vector2(dashSpeed, rb.velocity.y);
    }
    
    private void EndDash()
    {
        isDashing = false;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            UIManager.instance.ShowGameOverPanel();
            Destroy(this.gameObject);
        }
    }
}
