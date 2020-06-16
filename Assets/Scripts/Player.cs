using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    float move;
    bool isFacingRight = false;
    bool isGoingRight;

    public float speed = 90f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckForInput();
        CheckForFlip();
    }

    void CheckForInput()
    {
        move = Input.acceleration.x * 5;
        if(move > 0)
        {
            isGoingRight = true;
        }
        if(move < 0)
        {
            isGoingRight = false;
        }
    }

    void CheckForFlip()
    {
        if(isGoingRight != isFacingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        if (move != 0)
            Move(move);
    }

    void Move(float input)
    {
        float move = input * speed * Time.deltaTime;
        rb.velocity = new Vector2(move, rb.velocity.y);
    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        isFacingRight = !isFacingRight;
    }

    public bool GetOrientation()
    {
        return isFacingRight;
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
