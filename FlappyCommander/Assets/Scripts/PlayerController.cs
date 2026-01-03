using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text ammoText;
    public float flapForce = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public int clipSize = 10;
    public int currentAmmo;
    public float reloadTime = 1.5f;
    private bool isReloading = false;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentAmmo = clipSize;
    }

    void Update()
    {
        // Flap
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
        }

        // Shoot
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        // Reload
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(Reload());
        }
        ammoText.text = "Ammo: " + currentAmmo + " / " + clipSize;

    }

    void Shoot()
    {
        if (isReloading) return;

        if (currentAmmo > 0)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            currentAmmo--;
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    System.Collections.IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = clipSize;
        isReloading = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Time.timeScale = 0f;
            Debug.Log("Game Over");
            GameManager.instance.GameOver();
        }
    }

}
