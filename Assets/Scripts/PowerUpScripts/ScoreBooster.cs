
using UnityEngine;

public class ScoreBooster : BasePowerUP
{
    public static ScoreBooster Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        poweruptext = "2X Score";
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
