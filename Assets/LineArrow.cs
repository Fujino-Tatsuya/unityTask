using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineArrow : MonoBehaviour
{
    public float speed;
    [SerializeField] GameObject player;
    Vector3 dir = Vector3.zero;
    private void Awake()
    {
        player = GameObject.Find("player");
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        speed = 4.0f;
    }
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Out"))
        {
            gameObject.SetActive(false);
        }

        if (collision == player)
        {
            GameManager.isGameOver = true;
        }
    }
}
