using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sr;
    public TextMeshProUGUI textMP;
    public int number;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        textMP = GetComponentInChildren<TextMeshProUGUI>();
        number = Random.Range(2,10);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.contacts[0].normal.y > 0.5f) {
            StartCoroutine(DestroyObject());
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
