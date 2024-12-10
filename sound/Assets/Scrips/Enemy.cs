using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private AudioSource audioSource;
    private NewEnemy NewEnemy;

    private void Start()
    {
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
        }
    }

    public void Die()
    {
        audioSource.Play();
        GetComponent<Collider2D>().enabled = false;
        NewEnemy.SpawnEnemys();
        Invoke(nameof(WaitBeforDie), 1f);
    }

    private void WaitBeforDie()
    {
        Destroy(gameObject);
    }
}


