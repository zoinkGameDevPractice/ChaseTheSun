using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DirChanger : MonoBehaviour
{
    private void Awake()
    {
        transform.parent = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.ChangeDirection();
        }
    }
}