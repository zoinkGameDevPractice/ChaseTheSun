using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    [Range(0, 1)]
    public float smooth = .7f;

    // Update is called once per frame
    void LateUpdate()
    {
        if(player.position.y > transform.position.y)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.transform.position.y, -10), 1 / smooth * Time.deltaTime);
        }
    }
}
