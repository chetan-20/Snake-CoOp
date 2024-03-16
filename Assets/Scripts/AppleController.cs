using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AppleController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SnakeController>()!=null)
        {
            SoundController.Instance.PlaySound(Sounds.AppleEatingSound);
            SpawnFood.Instance.SpawnApple();
            Destroy(gameObject);
           SnakeController.Instance.GrowSnake();
            SnakeController.Instance.score += 10;//since score should increase only after eating food
        }
    }
}
