using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] private GameObject ApplePrefab;
    [SerializeField] private GameObject BadApplePrefab;
    [SerializeField] private GameObject ShieldPowerUpPrefab;
    [SerializeField] private GameObject ScoreBoostPrefab;
    [SerializeField] private GameObject SpeedBoostPowerUp;
    public static SpawnFood Instance;
    [SerializeField] private float minSpawntime = 1f;
    [SerializeField] private float maxSpawntime = 5f;
    [SerializeField] private float foodlifetime = 10f;
    private GameObject currentapple;
    private GameObject currentbadapple;
    internal GameObject currentpowerup;
    bool IsPowerUpSpawned = false;//Only one power up on screen at a time
    internal bool ispowerupover = true;//to spawn the next power up only after effect of previous one is over
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating("SpawnApple", Random.Range(minSpawntime, maxSpawntime), Random.Range(minSpawntime, maxSpawntime));
        InvokeRepeating("SpawnBadApple", Random.Range(minSpawntime, maxSpawntime)*1.5f, Random.Range(minSpawntime, maxSpawntime)*1.5f);//multiplied by 1.5 to slow down spawning of bad apple
        InvokeRepeating("SpawnPowerUp", Random.Range(minSpawntime, maxSpawntime) * 3f, Random.Range(minSpawntime, maxSpawntime) * 2f);//multiplied by 2 to slow down spawning of powerups
    }
    private void Update()
    {
        if (currentpowerup == null)
        {
            IsPowerUpSpawned = false;
        }
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


    public void SpawnPowerUp()
    {
        if (!IsPowerUpSpawned && ispowerupover)
        {
            float minX = 1f;
            float minY = 1f;
            float maxX = 19f;
            float maxY = 19f;

            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Vector2 spawnposition = new Vector2(randomX, randomY);
            int randomnumber = Random.Range(0, 3);
            if (randomnumber == 0)
            {
                currentpowerup = Instantiate(ShieldPowerUpPrefab, spawnposition, Quaternion.identity);
                IsPowerUpSpawned = true;
            }
            else if (randomnumber == 1)
            {
                currentpowerup = Instantiate(ScoreBoostPrefab, spawnposition, Quaternion.identity);
                IsPowerUpSpawned = true;
            }
            else if (randomnumber == 2)
            {
                currentpowerup = Instantiate(SpeedBoostPowerUp, spawnposition, Quaternion.identity);
                IsPowerUpSpawned = true;
            }

            Destroy(currentpowerup, foodlifetime);
            
        }
    }
}
    

