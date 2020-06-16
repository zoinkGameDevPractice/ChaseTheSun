using UnityEngine;

[CreateAssetMenu(fileName = "New Segment", menuName = "Segment")]
public class Segment : ScriptableObject
{
    public float minY;
    public float maxY;
    public int numberOfPlatforms;
    public GameObject[] platformPrefab;

    [Range(0, 100)]
    public int weight;

    public GameObject GetRandomPrefab()
    {
        return platformPrefab[Random.Range(0, platformPrefab.Length)];
    }

    public GameObject GetPrefabWithIndex(int index)
    {
        return platformPrefab[index];
    }
}
