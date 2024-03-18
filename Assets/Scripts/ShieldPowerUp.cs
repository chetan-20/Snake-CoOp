
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public static ShieldPowerUp Instance;
    private float powerupduration = 10f;
    internal bool iseaten=false;//will be used in other class to set up the effects
    internal bool iseffectover = false;
    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SnakeController>() != null)
        {
            ApplyEffect();           
            Invoke("RemoveEffect",powerupduration);
        }
    }
    
    private void ApplyEffect()
    {
        
        SoundController.Instance.PlaySound(Sounds.PowerUpSound);
        SpawnPowerUps.Instance.PowerUpPanel.text = "Shield Active!";
        iseaten = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

    }
   
    private void RemoveEffect()
    {      
             
        iseffectover = true;
    }
   
}
