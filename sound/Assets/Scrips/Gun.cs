using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject playerPos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private AudioSource shootAudioSource;
    [SerializeField] public TextMeshProUGUI healthText;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] public int lives = 3;
    private Rigidbody2D rb;
    public int enemyScore = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player.transform.position = playerPos.transform.position;
        healthText.text = $"Health: {lives}";
    }

    void Update()
    {
        MoveGun();
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            Shoot();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    void MoveGun()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        shootAudioSource.Play(); 
    }

    public void TakeDamage()
    {
        lives--;
        healthText.text = $"Health: {lives}";
        if (lives <= 0)
        {
            gameController.GameOver();
        }
    }
}
