using UnityEngine;

public class ScreenWrap : MonoBehaviour
{ 
    public Transform otherSide;
    public bool isRightSide;

    Vector2 playerPos;
    Vector2 lastPos;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerPos = collision.transform.position;
        }

        lastPos = playerPos;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(isRightSide)
        {
            if (lastPos.x > transform.position.x)
                Teleport(collision.transform);
        }
        if(!isRightSide)
        {
            if (lastPos.x < transform.position.x)
                Teleport(collision.transform);
        }
    }

    void Teleport(Transform transform)
    {
        transform.position = new Vector3(otherSide.position.x, transform.position.y);
    }
}
