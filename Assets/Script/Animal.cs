using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    private float moveX = 1;
    private float moveY = 1;
    private float changeDirectionInterval = 4f;
    private float timer = 0f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeDirectionInterval)
        {
            ChangeDirection();
            timer = 0f;
        }

        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (moveX > 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (moveX < 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);

        }
    }

    private void ChangeDirection()
    {
        moveX = Random.Range(-1f, 1f);
        moveY = Random.Range(-1f, 1f);
    }
}
