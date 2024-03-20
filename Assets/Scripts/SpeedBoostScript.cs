
using UnityEngine;

public class SpeedBoostScript : BasePowerUP
{
    public static SpeedBoostScript Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        poweruptext = "Speed Boost";
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
