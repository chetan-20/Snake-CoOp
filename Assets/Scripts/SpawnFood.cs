using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] private GameObject ApplePrefab;
    [SerializeField] private GameObject BadApplePrefab;
    
    public static SpawnFood Instance;
    [SerializeField] private float minSpawntime = 1f;
    [SerializeField] private float maxSpawntime = 5f;
    [SerializeField] private float foodlifetime = 10f;
    private GameObject currentapple;
    private GameObject currentbadapple;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating("SpawnApple", Random.Range(minSpawntime, maxSpawntime), Random.Range(minSpawntime, maxSpawntime));
        InvokeRepeating("SpawnBadApple", Random.Range(minSpawntime, maxSpawntime)*1.5f, Random.Range(minSpawntime, maxSpawntime)*1.5f);//multiplied by 1.5 to slow down spawning of bad apple
        
    }
    
    public void SpawnApple()
    {
        if (currentapple == null)//only one apple present
        {
            float minX = 1f;
            float minY = 1f;
            float maxX = 19f;
            float maxY = 19f;

            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Vector2 spawnposition = new Vector2(randomX, randomY);

            currentapple = Instantiate(ApplePrefab, spawnposition, Quaternion.identity);
            Destroy(currentapple, foodlifetime);
        }
    
    }
   
    public void SpawnBadApple()
    {
        if (currentbadapple == null && SnakeController.Instance.snakeSegments.Count>5)//if snake got more than 5 parts then only run
        {
            float minX = 1f;
            float minY = 1f;
            float maxX = 19f;
            float maxY = 19f;

            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Vector2 spawnposition = new Vector2(randomX, randomY);

            currentbadapple = Instantiate(BadApplePrefab, spawnposition, Quaternion.identity);
            Destroy(currentbadapple, foodlifetime);
        }
    }


   
}
    

