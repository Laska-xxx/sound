using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private AudioSource shootAudioSource;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float leftLimit = -3f;
    [SerializeField] private float rightLimit = 3f;
    [SerializeField] private int lives = 3;
    [SerializeField] private float damageRadius = 2f;
    private bool isGameOver = false;
    private bool isHit = false;

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

        if (isGameOver)
        {
            return;
        }

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, damageRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy") && !isHit)
            {
                TakeDamage();
                isHit = true; 
            }
        }
        if (hitColliders.Length == 0)
        {
            isHit = false;
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

    void TakeDamage()
    {
        lives--;
        healthText.text = $"Health: {lives}";
        if (lives <= 0)
        {
            GameOver();

        }
    }

    void GameOver()
    {
        isGameOver = true;
        
        Debug.Log("Game Over!"); 
    }
}
