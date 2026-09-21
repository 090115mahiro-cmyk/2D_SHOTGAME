using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float underPosition = -4.20f;
    [SerializeField] private float highPosition = 8.00f;
    PlayerData playerData = new PlayerData();
    [SerializeField] private GameObject Bullet;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //移動の制御
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S) && this.transform.position.y > underPosition)
        {
            rb.linearVelocity = Vector2.down * playerData.playerSpeed;
        }
        else if (Input.GetKey(KeyCode.W) && this.transform.position.y < highPosition)
        {
            rb.linearVelocity = Vector2.up * playerData.playerSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
    //射撃操作
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }
    //Enemyとの当たり判定処理、当たった時、ｈｐを減らす
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyState enemyState = new EnemyState();
            playerData.playerHp -= enemyState.attack;
            
        }
    }
}
