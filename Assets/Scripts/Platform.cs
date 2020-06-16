using UnityEngine;

public class Platform : MonoBehaviour
{
    public float bounciness = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.y <= 0f && collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            float velocity = rb.velocity.y;
            velocity = bounciness;
            rb.velocity += new Vector2(0, velocity);
        }
    }
}
