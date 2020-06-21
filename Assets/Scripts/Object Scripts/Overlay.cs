using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Overlay : MonoBehaviour
{
    public float outAnimationLength = 1f;

    public IEnumerator Destroy()
    {
        GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(outAnimationLength);
        Destroy(gameObject);
    }
}
