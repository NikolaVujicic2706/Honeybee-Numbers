using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sr;
    public TextMeshProUGUI textMP;
    public float destroyBoundary = -15.0f;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        textMP = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (transform.position.y < destroyBoundary)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.contacts[0].normal.x == 0) {
            StartCoroutine(DestroyObject());
        }
        else
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }

           
    }

    IEnumerator DestroyObject()
    {
        particle.Play();
        sr.enabled = false;
        textMP.enabled = false;
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);

    }
}
