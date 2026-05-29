using UnityEngine;

public class SpikyObstacle : MonoBehaviour
{
    public float speed = 2f;
    public int health = 3;

    void Update()
    {
        // Move left, similar to regular obstacles
        //transform.Translate(Vector2.left * speed * Time.deltaTime);

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
            // Award points for destroying a tough obstacle
            if (ScoreManager.instance != null)
                ScoreManager.instance.AddScore(3);
                
            Destroy(gameObject);
        }
    }
}