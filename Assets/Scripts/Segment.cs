using UnityEngine;

[CreateAssetMenu(fileName = "New Segment", menuName = "Segment")]
public class Segment : ScriptableObject
{
    [Header("Platform Distance Variation")]
    public float minY;
    public float maxY;

    [Space]

    [Header("Spawning Options")]
    public int numberOfPlatforms;
    public GameObject[] platformPrefab;
    [Space]
    public int numberOfEnemies;
    public GameObject[] enemyPrefab;

    [Space]

    [Header("Segment Probability")]
    [Range(0, 100)]
    public int weight;

    public GameObject GetRandomPlatformPrefab()
    {
        return platformPrefab[Random.Range(0, platformPrefab.Length)];
    }

    public GameObject GetPlatformPrefabWithIndex(int index)
    {
        return platformPrefab[index];
    }

    public GameObject GetRandomEnemyPrefab()
    {
        return enemyPrefab[Random.Range(0, enemyPrefab.Length)];
    }

    public GameObject GetEnemyPrefabWithIndex(int index)
    {
        return enemyPrefab[index];
    }
}
