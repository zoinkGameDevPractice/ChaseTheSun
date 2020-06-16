using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public const float minX = 1.25f;
    public const float maxX = 4.75f;

    public float maxXEnemyOffset = 1.5f;
    public float maxYEnemyOffset = 1.5f;

    public Segment[] segments;

    Segment currentSegment;

    List<GameObject> platforms = new List<GameObject>();
    GameObject lastPlatform = null;

    void Start()
    {
        GenerateSegment();
    }

    void Update()
    {
        if(lastPlatform != null && lastPlatform.transform.position.y <= transform.position.y)
        {
            lastPlatform = null;
            GenerateSegment();
        }
    }

    void GenerateSegment()
    {
        GeneratePlatforms();
        print(currentSegment);
        GenerateEnemies();
    }

    void GeneratePlatforms()
    {
        platforms = new List<GameObject>();

        Vector2 spawnPosition = transform.position;
        Segment s = GetSegment();
        currentSegment = s;

        GameObject prefab = s.GetRandomPlatformPrefab();

        for (int i = 0; i < s.numberOfPlatforms; i++)
        {
            spawnPosition = new Vector2(GetSpawnPosition().x, spawnPosition.y + GetSpawnPosition().y);
            platforms.Add(Instantiate(prefab, spawnPosition, Quaternion.identity));
        }

        lastPlatform = platforms[platforms.Count - 1];
    }

    void GenerateEnemies()
    {
        if(currentSegment.numberOfEnemies > 0)
        {
            GameObject prefab = currentSegment.GetRandomEnemyPrefab();

            int platsPerSection = Mathf.RoundToInt(currentSegment.numberOfPlatforms / currentSegment.numberOfEnemies);
            int numOfSections = Mathf.RoundToInt(currentSegment.numberOfPlatforms / platsPerSection);

            for (int i = 0; i < numOfSections; i++)
            {
                int rand = Random.Range(0, platsPerSection);
                int index = i * platsPerSection + rand;
                float xOffset = Random.Range(-maxXEnemyOffset, maxXEnemyOffset);
                float yOffset = Random.Range(-maxYEnemyOffset, maxYEnemyOffset);

                Vector2 spawnPosition = platforms[index].transform.position + new Vector3(xOffset, yOffset);

                Instantiate(prefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    Segment GetSegment()
    {
        int totalWeight = 0;

        List<Segment> newSegments = new List<Segment>();

        foreach (Segment s in segments)
        {
            totalWeight += s.weight;

            for(int i = 0; i < s.weight; i++)
            {
                newSegments.Add(s);
            }
        }

        int r = Random.Range(0, totalWeight);
        return newSegments[r];
    }

    Vector2 GetSpawnPosition()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(currentSegment.minY, currentSegment.maxY);

        return new Vector2(x, y);
    }
}
