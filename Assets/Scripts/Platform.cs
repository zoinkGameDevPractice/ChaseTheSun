using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.GetContact(0).point.y > transform.position.y && collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            float velocity = rb.velocity.y;
            velocity = jumpForce;
            rb.velocity += new Vector2(0, velocity);
        }
    }
}
