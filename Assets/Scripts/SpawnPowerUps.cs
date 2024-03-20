using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    [SerializeField] private GameObject ShieldPowerUpPrefab;
    [SerializeField] private GameObject ScoreBoostPrefab;
    [SerializeField] private GameObject SpeedBoostPowerUp;
    [SerializeField] private float minSpawntime = 5f;
    [SerializeField] private float maxSpawntime = 10f;
    [SerializeField] internal float poweruplifetime = 25f; 
    [SerializeField] internal TextMeshProUGUI CoopPowerUpPanel=null;
    [SerializeField] internal TextMeshProUGUI PowerUpPanel;
    private GameObject currentpowerup;
    public static SpawnPowerUps Instance;   
    bool IsPowerUpSpawned = false;//Only one power up on screen at a time 

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), minSpawntime*2, Random.Range(minSpawntime, maxSpawntime));
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
            if (SpeedBoostScript.Instance.Getiseffectover() == true)
            {
                ResetText();
                Destroy(currentpowerup);               
            }           
        }
         if (ScoreBooster.Instance != null)
         {          
            if (ScoreBooster.Instance.Getiseffectover() == true)
            {
                ResetText();
                Destroy(currentpowerup);
            }
            
         }
         if (ShieldPowerUp.Instance != null)
         {         
            if (ShieldPowerUp.Instance.Getiseffectover() == true)
            {
                ResetText();
                Destroy(currentpowerup);
            }          
         }              
    }

    private void ResetText()
    {
        PowerUpPanel.text = "";
        CoopPowerUpPanel.text = "";
    }

    public void SpawnPowerUp()
    {
        if (!IsPowerUpSpawned)
        {           
            Vector2 spawnposition = GridArea.Instance.GetRandomPosition();
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
            ResetText();
        }
    }
}
