using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    [SerializeField] private float massThreshold = 2f;
    [SerializeField] private AudioClip destructionSound;
    private Collider2D col;
    private SpriteRenderer rn;
    private AudioManager audio;

    private void Start()
    {
        audio = GetComponent<AudioManager>();
        col = GetComponent<Collider2D>();
        rn = GetComponent<SpriteRenderer>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (!rb) return;
        if (rb.mass >= massThreshold) DestroyWall();
    }

    public void DestroyWall()
    {
        col.enabled = false;
        rn.enabled = false;
        audio.Play(destructionSound);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Destroy(gameObject, gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().main.duration);
    }
}
