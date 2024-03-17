using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public static ShieldPowerUp Instance;
    private float powerupduration = 20f;
    internal bool ispowerupactive = false;//will be used in other class to set up the effects

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<SnakeController>() != null)
        {
            ApplyEffect();
            Invoke("RemoveEffect", powerupduration);//call after 10s to disable the powerup
        }
    }

    private void ApplyEffect()
    {
        SoundController.Instance.PlaySound(Sounds.PowerUpSound);
        gameObject.SetActive(false);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        ispowerupactive = true;
        SpawnFood.Instance.ispowerupover = false;//Stop spawning of other power ups
        
    }

    private void RemoveEffect()
    {
        ispowerupactive = false;
        SpawnFood.Instance.ispowerupover = true;//allow spawning of other power ups after effect of current one is over
       
        Destroy(gameObject);
    }
}
