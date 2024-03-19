using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    [SerializeField] private GameObject ShieldPowerUpPrefab;
    [SerializeField] private GameObject ScoreBoostPrefab;
    [SerializeField] private GameObject SpeedBoostPowerUp;
    [SerializeField] internal TextMeshProUGUI CoopPowerUpPanel=null;
    [SerializeField] internal TextMeshProUGUI PowerUpPanel;
    [SerializeField] private float minSpawntime = 5f;
    [SerializeField] private float maxSpawntime = 10f;
    [SerializeField] internal float poweruplifetime = 25f;
    public static SpawnPowerUps Instance;
    internal GameObject currentpowerup;
    bool IsPowerUpSpawned = false;//Only one power up on screen at a time
   

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InvokeRepeating("SpawnPowerUp", 5f, Random.Range(minSpawntime, maxSpawntime));
    }
    private void Update()
    {
        SetCurrentPowerUpStatus();
        CheckIsEffectover();
    }

    private void SetCurrentPowerUpStatus()
    {
        if (currentpowerup == null)
            {
                IsPowerUpSpawned = false;
            }
    }

   
    private void CheckIsEffectover()
    {
        if (SpeedBoostScript.Instance != null)
        {          
            if (SpeedBoostScript.Instance.iseffectover == true)
            {
                PowerUpPanel.text = "";
                CoopPowerUpPanel.text = "";
                Destroy(currentpowerup); 
                
            }
            
        }
         if (ScoreBooster.Instance != null)
         {          
            if (ScoreBooster.Instance.iseffectover == true)
            {
                PowerUpPanel.text = "";
                CoopPowerUpPanel.text = "";
                Destroy(currentpowerup);
            }
            
         }
         if (ShieldPowerUp.Instance != null)
         {         
            if (ShieldPowerUp.Instance.iseffectover == true)
            {
                PowerUpPanel.text = "";
                CoopPowerUpPanel.text = "";
                Destroy(currentpowerup);
            }
            
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
            Destroy(currentpowerup,poweruplifetime);
            PowerUpPanel.text = "";
            CoopPowerUpPanel.text = "";
        }
    }
}
