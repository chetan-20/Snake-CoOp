using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridArea : MonoBehaviour
{
    public static GridArea Instance;
    internal float minX = 1f;
    internal float minY = 1f;
    internal float maxX = 19f;
    internal float maxY = 19f;

    private void Awake()
    {
        Instance = this;
    }

    public Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }
}
