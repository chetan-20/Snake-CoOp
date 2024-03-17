using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBooster : MonoBehaviour
{
    public static ScoreBooster Instance;
    private float powerupduration = 20f;
    internal bool ispowerupactive = false;//will be used in other class to set up the effects

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SnakeController>() != null)
        {
            ApplyEffect();          
            StartCoroutine(RemoveEffectAfterDelay(powerupduration));//call after some time to disable the powerup
        }
    }

    private void ApplyEffect()
    {
        SoundController.Instance.PlaySound(Sounds.PowerUpSound); 
        ispowerupactive = true; 
        SpawnFood.Instance.ispowerupover = false;//Stop spawning of other power ups
        
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;      
       
    }
    private IEnumerator RemoveEffectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        RemoveEffect();
    }
    private void RemoveEffect()
    {
        
        ispowerupactive = false;
        SpawnFood.Instance.ispowerupover = true;//allow spawning of other power ups after effect of current one is over
        Debug.Log("Effect Removed");
        Destroy(gameObject);
    }

    
}
