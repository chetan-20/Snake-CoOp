using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{
    public static SpeedBoostScript Instance;
    private float powerupduration = 10f;
    internal bool iseaten = false;//will be used in other class to set up the effects

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SnakeController>() != null)
        {
            ApplyEffect();
            StartCoroutine(RemoveEffectAfterDelay(powerupduration));
        }
    }

    private void ApplyEffect()
    {
        Debug.Log("Started Effect");
        SoundController.Instance.PlaySound(Sounds.PowerUpSound);
        iseaten = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

    }
    private IEnumerator RemoveEffectAfterDelay(float delay)
    {
        Debug.Log("Started coroutine");
        yield return new WaitForSeconds(delay);
        RemoveEffect();
        Destroy(gameObject);
    }
    private void RemoveEffect()
    {
        Debug.Log("Effect Removed");
        iseaten = false; 
    }
}
