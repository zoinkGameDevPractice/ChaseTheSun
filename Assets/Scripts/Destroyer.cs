using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("Player"))
        {
            Player p = collision.GetComponent<Player>();
            p.Die();
        }

        if(collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.Die();
        }

        if(collision.CompareTag("EnemyCheckpoint"))
        {
            if(collision.transform.parent)
            {
                Enemy enemy = collision.GetComponentInParent<Enemy>();
                enemy.Die();
            }
        }
    }
}
