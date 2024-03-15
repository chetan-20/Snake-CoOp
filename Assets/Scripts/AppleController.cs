using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            Destroy(gameObject);
            SpawnFood.Instance.SpawnApple();
            Debug.Log("Eaten");
        }
    }
}
