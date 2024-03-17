using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    [SerializeField] private GameObject ShieldPowerUpPrefab;
    [SerializeField] private GameObject ScoreBoostPrefab;
    [SerializeField] private GameObject SpeedBoostPowerUp;
    [SerializeField] private float minSpawntime = 5f;
    [SerializeField] private float maxSpawntime = 10f;
    [SerializeField] private float foodlifetime = 7f;
    public static SpawnPowerUps Instance;
    internal GameObject currentpowerup;
    bool IsPowerUpSpawned = false;//Only one power up on screen at a time
   

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InvokeRepeating("SpawnPowerUp", 10f, Random.Range(minSpawntime, maxSpawntime));
    }
    private void Update()
    {
        if (currentpowerup == null)
        {
            IsPowerUpSpawned = false;
        }
    }
    public void SpawnPowerUp()
    {

        if (!IsPowerUpSpawned)
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
                if (ShieldPowerUp.Instance.iseaten == true)
                {
                    return;
                }
            }
            else if (randomnumber == 1)
            {
                currentpowerup = Instantiate(ScoreBoostPrefab, spawnposition, Quaternion.identity);
                IsPowerUpSpawned = true;
                if (ScoreBooster.Instance.iseaten == true)
                {
                    return;
                }
            }
            else if (randomnumber == 2)
            {
                currentpowerup = Instantiate(SpeedBoostPowerUp, spawnposition, Quaternion.identity);
                IsPowerUpSpawned = true;
                if (SpeedBoostScript.Instance.iseaten==true)
                {
                    return;
                }
            }           
            if(currentpowerup!=null)
            {
                Destroy(currentpowerup, foodlifetime);
            }
        }
    }
}
