using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCube : MonoBehaviour
{
    [SerializeField] private float massThreshold = 2;
    private Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();
        if (!rigid) return;
        if (rigid.mass < massThreshold && collision.gameObject.tag == "Player")
            Physics2D.IgnoreCollision(col, collision.collider);
    }
}
