using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SnakeParent : MonoBehaviour
{    
    [SerializeField] protected GameObject snakeBodyPrefab;
    [SerializeField] protected int snakeSpeed = 7;
    protected Rigidbody2D rb;
    protected Vector2Int gridMoveDirection;   
    protected bool canCheckCollision = false;
    protected bool selfCollision = false;
    protected float delayCollisionCheckTime = 3f; 
    internal List<Transform> snakeSegments = new List<Transform>();
    internal int score = 0;
    protected int scoreboost = 10;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        snakeSegments.Add(transform); // Adding the head
        DefaultSnakeLength(4);
    }
    protected virtual void Update()
    {
        HandleInput();
        HandleGridMovement();
        ScreenWrap();
        CheckSelfCollision();
        SetSpeedBoost();
    }
    protected virtual void FixedUpdate()
    {
        MoveSnakeBody();
    }

    protected virtual void HandleGridMovement()
    {
        Vector2 movement = gridMoveDirection * snakeSpeed;
        rb.velocity = movement;
    }

    protected virtual void ScreenWrap()
    {
        Vector3 currentPosition = transform.position;            
        if (currentPosition.x > GridArea.Instance.rightBound)
        {
            currentPosition.x = GridArea.Instance.leftBound;

            transform.position = currentPosition;
        }
        else if (currentPosition.x < GridArea.Instance.leftBound)
        {
            currentPosition.x = GridArea.Instance.rightBound;

            transform.position = currentPosition;
        }

        if (currentPosition.y > GridArea.Instance.upperBound)
        {
            currentPosition.y = GridArea.Instance.lowerBound;

            transform.position = currentPosition;
        }
        else if (currentPosition.y < GridArea.Instance.lowerBound)
        {
            currentPosition.y = GridArea.Instance.upperBound;

            transform.position = currentPosition;
        }
    }

    public void GrowSnake()
    {
        Vector3 lastSegmentPosition = snakeSegments[snakeSegments.Count - 1].position;
        GameObject newSegment = Instantiate(snakeBodyPrefab, lastSegmentPosition, Quaternion.identity, transform.parent);
        snakeSegments.Add(newSegment.transform);
        if (GetScoreBoostStatus())
        {
            score += scoreboost;//Double the score for that duration
        }
    }

    public void DestroyTail(int count)
    {
        if (count < snakeSegments.Count)
        {
            for (int i = 0; i < count; i++)
            {               
                Transform tailSegment = snakeSegments[snakeSegments.Count - 1];                
                snakeSegments.RemoveAt(snakeSegments.Count - 1);              
                Destroy(tailSegment.gameObject);
            }
        }
    }

    protected virtual void MoveSnakeBody()
    {
        for (int i = snakeSegments.Count - 1; i > 0; i--)
        {
            // Move the current segment to the position of the segment in front of it
            snakeSegments[i].position = snakeSegments[i - 1].position;
        }
    }

    protected abstract void DefaultSnakeLength(int bodyLength);

    protected abstract void CheckSelfCollision();

    protected abstract bool GetShieldStatus();

    protected abstract bool GetScoreBoostStatus();

    protected abstract void SetSpeedBoost();
    protected abstract void HandleInput();

    
}
