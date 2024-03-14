using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private Vector2Int gridposition;
    private Vector2Int gridmovedirection;
    private float gridmovetimermax;
    private float gridmovetimer;

    private void Awake()
    {
        gridposition = new Vector2Int(10,10);
        gridmovetimermax = .25f;
        gridmovetimer = gridmovetimermax;
        gridmovedirection = new Vector2Int(1,0);
        RotateSprite(0f);
    }

    private void Update()
    {
        HandleInput();
        HandleGridMovement();
        
    }

    private void HandleInput()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            if (gridmovedirection.y != -1)
            {
                gridmovedirection.y = 1;
                gridmovedirection.x = 0;
                RotateSprite(90f);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (gridmovedirection.y != 1)
            {
                gridmovedirection.y = -1;
                gridmovedirection.x = 0;
                RotateSprite(-90f);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (gridmovedirection.x != -1)
            {
                gridmovedirection.y = 0;
                gridmovedirection.x = +1;
                RotateSprite(0f);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (gridmovedirection.x != 1)
            {
                gridmovedirection.y = 0;
                gridmovedirection.x = -1;
                RotateSprite(-180f);
            }
        }
    }

    private void HandleGridMovement()
    {
       
        gridmovetimer += Time.deltaTime;
        if (gridmovetimer >= gridmovetimermax)
        {
            gridmovetimer -= gridmovetimermax;
            gridposition += gridmovedirection;
            
           transform.position = new Vector3(gridposition.x, gridposition.y);
        }
         
    }

    private void RotateSprite(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle-90f);
    }
}
