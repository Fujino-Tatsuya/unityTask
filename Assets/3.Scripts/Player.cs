using System;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int state;
    public float moveSpeed;
    bool flip;
    bool isVanish;
    bool isRun;
    public float deathTime;

    SpriteRenderer spr;
    Animator anim;


    void Start()
    {
        moveSpeed = 5.0f;
        flip = true;
        deathTime = 2;

        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (!isVanish)
        {
            Move();
            AnimeManager();

        }
    }

    void Move()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1f;
            flip = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vertical = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
            flip = true;
        }

        Vector3 moveDirection = new Vector3(horizontal, vertical, 0).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void AnimeManager()
    {
        spr.flipX = flip;

        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Arrow")//화살 맞으면 사망
        {
            isVanish = true;
            anim.SetBool("Death", true);
            GameManager.isGameOver = true;
            Destroy(gameObject, deathTime);
        }
    }
}
