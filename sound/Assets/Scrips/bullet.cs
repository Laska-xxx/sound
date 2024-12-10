using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource shootAudio;
    private float currLifeTime;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move() => rb.velocity = transform.right * speed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shootAudio.Play();
        Destroy(gameObject);
    }

    
}
