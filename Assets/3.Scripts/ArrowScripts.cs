using UnityEngine;

public class ArrowScripts : MonoBehaviour
{
    public float speed;
    [SerializeField] GameObject player;
    Vector3 dir;
    private void Awake()
    {
        player = GameObject.Find("player");
        dir = (player.transform.position - gameObject.transform.position).normalized;
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
        if(collision.CompareTag("Out"))
        {
            gameObject.SetActive(false);
        }

        if(collision == player)
        {
            GameManager.isGameOver = true;
        }
    }
}
