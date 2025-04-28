using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Controller")]
    [SerializeField]private float jumpForce;
    private Rigidbody2D rb;
    
    [Header("Shooting")]
    [SerializeField]private Transform bulletspawnPoint;
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]private float fireRate = 0.3f;
    private float nextFireTime = 0f;

    [Header("Auto Fire")]
    [SerializeField]private bool autoFire = true; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    
        if (autoFire && Time.time >= nextFireTime)
        {
            ShootBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    void ShootBullet()
    {
        if (bulletPrefab && bulletspawnPoint)
        {
            Instantiate(bulletPrefab, bulletspawnPoint.position, bulletspawnPoint.rotation);
        }
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
