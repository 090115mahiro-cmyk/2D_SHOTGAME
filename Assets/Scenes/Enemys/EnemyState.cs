using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public float hp = 5.0f;
    public float attack = 2.0f;
    public float speed = -4.0f;
    private Rigidbody2D rb;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;   
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
