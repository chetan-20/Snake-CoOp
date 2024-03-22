using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BadAppleController : MonoBehaviour
{
    [SerializeField] private int point = 20;
    [SerializeField] private int taillength = 2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SnakeController>() != null)
        {
            SoundController.Instance.PlaySound(Sounds.BadAppleEatingSound);
            SpawnFood.Instance.SpawnBadApple();
            Destroy(gameObject);
            SnakeController.Instance.DestroyTail(taillength);
            SnakeController.Instance.score -= point;
            if (SnakeController.Instance.score < 0)
            {
                SnakeController.Instance.score = 0;
            }
        }
        if (collision.gameObject.GetComponent<CoopSnakeController>() != null)
        {
            SoundController.Instance.PlaySound(Sounds.BadAppleEatingSound);
            SpawnFood.Instance.SpawnBadApple();
            Destroy(gameObject);
            CoopSnakeController.Instance.DestroyTail(taillength);
            CoopSnakeController.Instance.score -= point;
            if (CoopSnakeController.Instance.score < 0)
            {
                CoopSnakeController.Instance.score = 0;
            }
        }
    }  
}
