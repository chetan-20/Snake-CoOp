using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BadAppleController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SnakeController>() != null)
        {
            SpawnFood.Instance.SpawnBadApple();
            Destroy(gameObject);
            SnakeController.Instance.DestroyTail(3);
            SnakeController.Instance.score -= 30;//decrease by 30
            if (SnakeController.Instance.score < 0)
            {
                SnakeController.Instance.score = 0;
            }
        }
    }
}
