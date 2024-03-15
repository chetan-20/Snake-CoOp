using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private Vector2Int gridposition;
    private Vector2Int gridmovedirection;
    [SerializeField] private GameObject snakeBodyPrefab;
    private Rigidbody2D rb;
    [SerializeField] private int snakeSpeed = 1;
    public static SnakeController Instance;
    private List<Transform> snakeSegments = new List<Transform>();
    private void Awake()
    {
        Instance= this;
        gridposition = new Vector2Int(10,10);      
        gridmovedirection = new Vector2Int(1,0);
        RotateSprite(0f);
        rb = GetComponent<Rigidbody2D>();
        snakeSegments.Add(transform);//Adding the head;
        DefaultSnakeLength(5);
    }

    private void Update()
    {
        HandleInput();
        HandleGridMovement();
        ScreenWrap();
        
    }

    private void FixedUpdate()
    {
        MoveSnakeBody();
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
        float rightBound = 19.5f;
        float leftBound = 0.5f;
        float upperBound = 19.5f;
        float lowerBound = 0.5f;

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

    public void GrowSnake()
    {
        // Get the position of the last segment
        Vector3 lastSegmentPosition = snakeSegments[snakeSegments.Count - 1].position;

        // Create a new snake segment at the last segment's position
        GameObject newSegment = Instantiate(snakeBodyPrefab, lastSegmentPosition, Quaternion.identity, transform.parent);
        snakeSegments.Add(newSegment.transform); // Add the new segment to the list
    }

    private void MoveSnakeBody()
    {
        for (int i = snakeSegments.Count - 1; i > 0; i--)
        {
            // Move the current segment to the position of the segment in front of it
            snakeSegments[i].position = snakeSegments[i - 1].position;
        }
    }

    private void DefaultSnakeLength(int bodyLength)
    {
        for(int i = 0;i < bodyLength; i++)
        {
            GrowSnake();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SnakeBody"))
        {
            Debug.Log("GameOVer");
        }
    }
}





















/*private float gridmovetimermax;
    //private float gridmovetimer;
    /*gridmovetimer += Time.deltaTime;
        if (gridmovetimer >= gridmovetimermax)
        {
            gridmovetimer -= gridmovetimermax;
            gridposition += gridmovedirection;
            
           transform.position = new Vector3(gridposition.x, gridposition.y);
        }
    gridmovetimermax = .25f;
    gridmovetimer = gridmovetimermax;*/
