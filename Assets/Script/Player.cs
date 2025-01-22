using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 10f;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject bulletPrefab;
    private Animator animator;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        cam.transform.position = this.transform.position + new Vector3(0, 0, -10);

        if(moveX != 0 || moveY != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (moveX > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveX < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }

        this.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.GotoHome();
        }
    }

    void Shoot()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootDir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(shootDir);
    }
}
