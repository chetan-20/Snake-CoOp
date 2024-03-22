using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AppleController : MonoBehaviour
{
    [SerializeField] private int points = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SnakeController>()!=null)
        {
            SoundController.Instance.PlaySound(Sounds.AppleEatingSound);
            SpawnFood.Instance.SpawnApple();
            Destroy(gameObject);
            SnakeController.Instance.GrowSnake();
            SnakeController.Instance.score += points;            
        }
        if (collision.gameObject.GetComponent<CoopSnakeController>() != null)
        {
            SoundController.Instance.PlaySound(Sounds.AppleEatingSound);
            SpawnFood.Instance.SpawnApple();
            Destroy(gameObject);
            CoopSnakeController.Instance.GrowSnake();
            CoopSnakeController.Instance.score += points;
        }
    }  
}
