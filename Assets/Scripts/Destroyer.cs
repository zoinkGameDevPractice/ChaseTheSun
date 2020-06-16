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
    }
}
