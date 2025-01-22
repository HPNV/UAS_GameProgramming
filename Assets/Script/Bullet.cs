using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    private Vector2 direction;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.instance.AddKill();
            GameManager.instance.Save();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
