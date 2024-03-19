
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{
    public static SpeedBoostScript Instance;
    private float powerupduration = 10f;
    internal bool iseaten = false;//will be used in other class to set up the effects
    internal bool iseffectover = false;
    internal bool coopiseaten = false;
    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SnakeController>() != null)
        {
            ApplyEffect();          
            Invoke("RemoveEffect", powerupduration);           
        }
        if (collision.gameObject.CompareTag("CoopSnake"))
        {
            CoopApplyEffect();
            Invoke("RemoveEffect", powerupduration);
        }
    }
   
    private void ApplyEffect()
    {
        
       
        SoundController.Instance.PlaySound(Sounds.PowerUpSound);
        iseaten = true;
        SpawnPowerUps.Instance.PowerUpPanel.text = "Speed Boost!";
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    private void CoopApplyEffect()
    {


        SoundController.Instance.PlaySound(Sounds.PowerUpSound);
        SpawnPowerUps.Instance.CoopPowerUpPanel.text = "Speed Boost!";
        coopiseaten = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

    }

    private void RemoveEffect()
    {                      
        iseffectover = true;       
    }
   
    
   
}
