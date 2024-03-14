using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAsset : MonoBehaviour
{
    public static GameAsset instance;
    [SerializeField] Sprite SnakeHeadSprite;
    private void Awake()
    {
        instance = this;
    }
}
