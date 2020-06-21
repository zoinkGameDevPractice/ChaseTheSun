using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 25f;
    public float bounciness = 10f;

    Vector2 nextPos;

    bool goRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(goRight)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        if(!goRight)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
    }

    public void ChangeDirection()
    {
        goRight = !goRight;
        Flip();
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if(collision.relativeVelocity.y > 0f)
            {
                player.Die();
            }

            if(collision.relativeVelocity.y < 0f)
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.velocity += new Vector2(0, bounciness);
                Die();
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
