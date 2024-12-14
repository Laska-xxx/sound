using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private AudioSource audioSource;
    private Gun gun;

    private void Start()
    {
        audioSource = GameObject.FindWithTag("PanchEnemy").GetComponent<AudioSource>();
        StartCoroutine(MoveToPlayer());
    }

    private IEnumerator MoveToPlayer()
    {
        while (true)
        {
            Transform player = FindObjectOfType<Gun>().transform;
            if (player != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out bullet _))
        {
            Die();
            gun.enemyScore++;
            Debug.Log(gun.enemyScore);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Die();
        }  
    }

    public void Die()
    {
        audioSource.Play();
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1f);
    }
}


