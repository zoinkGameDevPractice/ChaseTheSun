using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    float move;

    public float speed = 95f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckForInput();
    }

    void CheckForInput()
    {
        move = Input.acceleration.x;
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
}
