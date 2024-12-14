using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    private Rigidbody2D rb;
    private AudioSource panchAudio;
    private float currLifeTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        panchAudio = GameObject.FindWithTag("Panch").GetComponent<AudioSource>();
    }

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
        float x = 0.5f;
        panchAudio.Play();
        Destroy(gameObject, x);


    }
}
