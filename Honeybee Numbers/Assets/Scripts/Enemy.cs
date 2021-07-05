using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sr;
    private TextMeshProUGUI textMP;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        textMP = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        StartCoroutine(DestroyObject());

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
