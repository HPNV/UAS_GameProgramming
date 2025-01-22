using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    private Transform player;
    private Vector2 moveDirection;
    private Vector2 target;
    private float currentDistance;
    private Animator animator;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        target = new Vector2(player.position.x, player.position.y);
        currentDistance = Vector2.Distance(this.transform.position, target);

        if (currentDistance < 10)
        {
            animator.SetBool("isRunning", true);
            moveDirection = (target - rb.position).normalized * moveSpeed;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
        else
        {
            animator.SetBool("isRunning", false);
            rb.velocity = Vector2.zero;
        }

        if (moveDirection.x > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveDirection.x < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
