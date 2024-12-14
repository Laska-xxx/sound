using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private AudioSource shootAudioSource;
    [SerializeField] public TextMeshProUGUI healthText;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float leftLimit = -7f;
    [SerializeField] private float rightLimit = 0f;
    [SerializeField] public int lives = 3;
    public int enemyScore = 0;
    private GameController gameController;

    private void Start()
    {
        healthText.text = $"Health: {lives}";
    }

    void Update()
    {
        MoveGun();
        if (Input.GetMouseButtonDown(0))
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
        float move = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + Vector3.right * move * moveSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, leftLimit, rightLimit);
        transform.position = newPosition;
        shootAudioSource.panStereo = transform.position.x / rightLimit;
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
