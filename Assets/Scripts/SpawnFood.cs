using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] private GameObject ApplePrefab;
    public static SpawnFood Instance;

    private void Awake()
    {
        Instance = this;
    }
   
    public void SpawnApple()
    {      
            float minX = 1f;
            float minY = 1f;
            float maxX = 19f;
            float maxY = 19f;

            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Vector2 spawnposition = new Vector2(randomX, randomY);

            Instantiate(ApplePrefab, spawnposition, Quaternion.identity);                         
    }

    
}
