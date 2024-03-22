using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoopSnakeController : SnakeParent
{
    public static CoopSnakeController Instance;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
        gridmovedirection = new Vector2Int(-1, 0);
    }
    protected override void HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (gridmovedirection.y != -1)
            {
                gridmovedirection.y = 1;
                gridmovedirection.x = 0;
                RotateSprite(0f);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (gridmovedirection.y != 1)
            {
                gridmovedirection.y = -1;
                gridmovedirection.x = 0;
                RotateSprite(-180f);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (gridmovedirection.x != -1)
            {
                gridmovedirection.y = 0;
                gridmovedirection.x = +1;
                RotateSprite(-90f);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (gridmovedirection.x != 1)
            {
                gridmovedirection.y = 0;
                gridmovedirection.x = -1;
                RotateSprite(90f);
            }
        }
    }
    protected override void CheckSelfCollision()
    {
        if (canCheckCollision == true)//needed so collision isnt detected at start of the game
        {
            if (!GetShieldStatus())//shield check
            {
                Vector3 headPosition = transform.position;
                for (int i = 1; i < snakeSegments.Count; i++)
                {
                    if (snakeSegments[i].position == headPosition)
                    {
                        selfcollision = true;
                    }
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            delaycollisionchecktime -= Time.deltaTime;
            if (delaycollisionchecktime <= 0)
            {
                canCheckCollision = true;
            }
        }
    }   
    protected override bool GetShieldStatus()
    {
        return ShieldPowerUp.Instance != null && ShieldPowerUp.Instance.Getcoopiseaten();
    }
    protected override bool GetScoreBoostStatus()
    {
        return ScoreBooster.Instance != null && ScoreBooster.Instance.Getcoopiseaten();
    }
    protected override void SetSpeedBoost()
    {
        if (SpeedBoostScript.Instance != null && SpeedBoostScript.Instance.Getcoopiseaten())
        {
            snakeSpeed = snakeboostspeed;
        }
        else
        {
            snakeSpeed = snakedefaultspeed;
        }
    }
}
