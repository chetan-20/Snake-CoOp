using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private Vector2Int gridposition;
    private Vector2Int gridmovedirection;
    //private float gridmovetimermax;
    //private float gridmovetimer;
    private Rigidbody2D rb;
    [SerializeField] private int snakeSpeed = 1;
    private void Awake()
    {
        gridposition = new Vector2Int(10,10);
       // gridmovetimermax = .25f;
        //gridmovetimer = gridmovetimermax;
        gridmovedirection = new Vector2Int(1,0);
        RotateSprite(0f);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
        HandleGridMovement();
        ScreenWrap();
        
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

        /*gridmovetimer += Time.deltaTime;
        if (gridmovetimer >= gridmovetimermax)
        {
            gridmovetimer -= gridmovetimermax;
            gridposition += gridmovedirection;
            
           transform.position = new Vector3(gridposition.x, gridposition.y);
        }*/
        Vector2 movement = gridmovedirection * snakeSpeed;
        rb.velocity = movement;

    }

    private void RotateSprite(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle-90f);
    }

    private void ScreenWrap()
    {
        Vector3 currentPosition = transform.position;

        //screen boundary
        float rightBound = 20f;
        float leftBound = 0f;
        float upperBound = 20f;
        float lowerBound = 0f;

        // Check if the object is outside the screen bounds
        if (currentPosition.x > rightBound)
        {
            currentPosition.x = leftBound;
           
            transform.position = currentPosition;
        }
        else if (currentPosition.x < leftBound)
        {
            currentPosition.x = rightBound;
           
            transform.position = currentPosition;
        }

        if (currentPosition.y > upperBound)
        {
            currentPosition.y = lowerBound;
            
            transform.position = currentPosition;
        }
        else if (currentPosition.y < lowerBound)
        {
            currentPosition.y = upperBound;
           
            transform.position = currentPosition;
        }

        
    }
}
