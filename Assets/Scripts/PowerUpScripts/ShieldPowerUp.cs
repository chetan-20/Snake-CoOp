
using UnityEngine;

public class ShieldPowerUp : BasePowerUP
{
    public static ShieldPowerUp Instance;     
    private void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        poweruptext = "Shield Active";
        SnakeController snakeController = collision.gameObject.GetComponent<SnakeController>();
        CoopSnakeController coopSnakeController = collision.gameObject.GetComponent<CoopSnakeController>();
        if (snakeController != null)
        {
            ApplyEffect(poweruptext);
            Invoke(nameof(RemoveEffect), powerupduration);
        }
        else if (coopSnakeController != null)
        {
            CoopApplyEffect(poweruptext);
            Invoke(nameof(RemoveEffect), powerupduration);
        }
    }  
}
