using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] private GameObject ApplePrefab;
    [SerializeField] private GameObject BadApplePrefab;
    [SerializeField] private float minSpawntime = 1f;
    [SerializeField] private float maxSpawntime = 5f;
    [SerializeField] private float foodlifetime = 10f;
    private GameObject currentapple;
    private GameObject currentbadapple;
    public static SpawnFood Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnApple), Random.Range(minSpawntime, maxSpawntime), Random.Range(minSpawntime, maxSpawntime));
        InvokeRepeating(nameof(SpawnBadApple), Random.Range(minSpawntime, maxSpawntime)*1.5f, Random.Range(minSpawntime, maxSpawntime)*1.5f);//multiplied by 1.5 to slow down spawning of bad apple       
    }
    
    public void SpawnApple()
    {
        if (currentapple == null)//only one apple present
        {
            Vector2 spawnposition = GridArea.Instance.GetRandomPosition();
            currentapple = Instantiate(ApplePrefab, spawnposition, Quaternion.identity);
            Destroy(currentapple, foodlifetime);
        }
    
    }
   
    public void SpawnBadApple()
    {
        if (CoopSnakeController.Instance == null)//Single Player Active
        {
            if (currentbadapple == null && SnakeController.Instance.snakeSegments.Count > 5)//if snake got more than 5 parts then only run
            {
                Vector2 spawnposition = GridArea.Instance.GetRandomPosition();
                currentbadapple = Instantiate(BadApplePrefab, spawnposition, Quaternion.identity);
                Destroy(currentbadapple, foodlifetime);
            }
        }
        else
        {
            if (currentbadapple == null )
            {
                Vector2 spawnposition = GridArea.Instance.GetRandomPosition();
                currentbadapple = Instantiate(BadApplePrefab, spawnposition, Quaternion.identity);
                Destroy(currentbadapple, foodlifetime);
            }
        }
    }
  
}
    

