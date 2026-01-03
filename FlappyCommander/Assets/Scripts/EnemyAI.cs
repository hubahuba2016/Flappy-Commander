using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float followSpeed = 1.5f;
    public int health = 2;

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Move left
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // Follow player vertically
        if (player != null)
        {
            float targetY = player.position.y;
            transform.position = Vector2.Lerp(
                transform.position,
                new Vector2(transform.position.x, targetY),
                followSpeed * Time.deltaTime
            );
        }

        // Destroy if off-screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            ScoreManager.instance.AddScore(2);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            Debug.Log("Game Over - Enemy Hit");
            GameManager.instance.GameOver();
        }
    }
}
