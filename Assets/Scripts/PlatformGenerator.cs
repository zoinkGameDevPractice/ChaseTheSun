using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public const float minX = 1.25f;
    public const float maxX = 4.75f;

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
        Vector2 spawnPosition = transform.position;
        Segment s = GetSegment();
        currentSegment = s;

        GameObject prefab = s.GetRandomPrefab();

        for(int i = 0; i < s.numberOfPlatforms; i++)
        {
            spawnPosition = new Vector2(GetSpawnPosition().x, spawnPosition.y + GetSpawnPosition().y);
            platforms.Add(Instantiate(prefab, spawnPosition, Quaternion.identity));
        }

        lastPlatform = platforms[platforms.Count - 1];
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
