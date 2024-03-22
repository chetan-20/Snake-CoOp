using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SnakeParent : MonoBehaviour
{       
    [SerializeField] protected GameObject snakeBodyPrefab;
    [SerializeField] protected int snakeSpeed = 7;
    protected static int snakedefaultspeed = 7;
    protected static int snakeboostspeed = 10;
    protected Rigidbody2D rb;
    protected Vector2Int gridmovedirection;   
    protected bool canCheckCollision = false;    
    protected float delaycollisionchecktime = 3f;
    protected int defaullength = 4;
    protected int scoreboost = 10; 
    internal List<Transform> snakeSegments = new List<Transform>();
    internal int score = 0;
    internal bool selfcollision = false;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        snakeSegments.Add(transform); // Adding the head
        SpawnLength(defaullength);
    }
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    protected virtual void Update()
    {
        HandleInput();
        HandleGridMovement();
        SetSpeedBoost();
        ScreenWrap();
        CheckSelfCollision();
        GameManager.Instance.OnGameOver();
    }
    protected virtual void FixedUpdate()
    {
        MoveSnakeBody();
    }

    protected virtual void HandleGridMovement()
    {
        Vector2 movement = gridmovedirection * snakeSpeed;
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

    public virtual void GrowSnake()
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

    public void RotateSprite(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    protected void SpawnLength(int bodyLength)
    {
        for (int i = 0; i < bodyLength; i++)
        {
            GrowSnake();
        }
    }
    protected abstract void CheckSelfCollision();   
    protected abstract void HandleInput();
    protected abstract bool GetShieldStatus();
    protected abstract bool GetScoreBoostStatus();
    protected abstract void SetSpeedBoost();
}
