using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI FinalScore;
    [SerializeField] private TextMeshProUGUI snakescoreUI;
    [SerializeField] private TextMeshProUGUI coopsnakescoreUI;
    [SerializeField] private GameObject LevelObject;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject CoOpParent;
    [SerializeField] private GameObject SingleParent;
    [SerializeField] private GameObject ScoreUIObject;
    [SerializeField] private GameObject CoOPScoreUIObject;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject CoOpGameOverPanel;
    [SerializeField] private GameObject PowerUpUIObject;
    [SerializeField] private GameObject CoOpPowerUpUIObject;
    [SerializeField] internal TextMeshProUGUI coopwintext;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Time.timeScale = 1.0f;
        ActivateCoOPUI();
    }
    private void Update()
    {
        UpdateScoreUI();
        OnEscapePressed();      
        CheckSnakeBite();
    }
    private void ActivateCoOPUI()
    {
        if (CoopSnakeController.Instance != null)
        {
            CoOpParent.SetActive(true);
        }
        else
        {
            CoOpParent.SetActive(false);
        }
    }
    private void UpdateScoreUI()
    {
       
        if (SnakeController.Instance != null && CoopSnakeController.Instance != null)
        {
            snakescoreUI.text = "P1 Score : " + SnakeController.Instance.score;
            coopsnakescoreUI.text = "P2 Score : " + CoopSnakeController.Instance.score;
        }
        else if (SnakeController.Instance != null)
        {
            scoreUI.text = "Score : " + SnakeController.Instance.score;
        }
    }   
    public void PauseGame()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
        LevelObject.SetActive(false);
        ScoreUIObject.SetActive(false);
        PowerUpUIObject.SetActive(false);
        CoOPScoreUIObject.SetActive(false);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        SoundController.Instance.PlaySound(Sounds.ButtonClickSound);
        PausePanel.SetActive(false);
        LevelObject.SetActive(true);
        ScoreUIObject.SetActive(true);
        PowerUpUIObject.SetActive(true);
        if (CoopSnakeController.Instance != null)
        {
            CoOPScoreUIObject.SetActive(true);
        }
    }
    private void OnEscapePressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void LoadMenu()
    {
        SoundController.Instance.PlaySound(Sounds.ButtonClickSound);
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        SoundController.Instance.PlaySound(Sounds.ButtonClickSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }  
    internal void OnGameOver()
    {
        if (CoopSnakeController.Instance == null)
        {
            if (SnakeController.Instance.selfcollision == true) 
            {
                SoundController.Instance.PlaySound(Sounds.GameOverSound);
                Time.timeScale = 0f;
                LevelObject.SetActive(false);
                ScoreUIObject.SetActive(false);
                GameOverPanel.SetActive(true);
                PowerUpUIObject.SetActive(false);
                FinalScore.text = "Final Score : " + SnakeController.Instance.score;
            }
        }
        else if(SnakeController.Instance != null && CoopSnakeController.Instance != null)
        {           
            if(SnakeController.Instance.selfcollision == true)
            {
                SoundController.Instance.PlaySound(Sounds.GameOverSound);
                Time.timeScale = 0f;
                LevelObject.SetActive(false);
                CoOPScoreUIObject.SetActive(false);
                CoOpGameOverPanel.SetActive(true);
                coopwintext.text = ("Snake 2 Won");
            }
            if(CoopSnakeController.Instance.selfcollision == true)
            {
                SoundController.Instance.PlaySound(Sounds.GameOverSound);
                Time.timeScale = 0f;
                LevelObject.SetActive(false);
                CoOPScoreUIObject.SetActive(false);
                CoOpGameOverPanel.SetActive(true);
                coopwintext.text = ("Snake 1 Won");
            }
        }
    }
    private void CheckSnakeBite()
    {
        if (SnakeController.Instance != null && CoopSnakeController.Instance != null)
        {
            Vector3 snake1headPosition = SnakeController.Instance.transform.position;
            for (int i = 1; i < CoopSnakeController.Instance.snakeSegments.Count; i++)
            {
                if (Vector3.Distance(CoopSnakeController.Instance.snakeSegments[i].transform.position, snake1headPosition) < 0.8f)
                {
                    SnakeController.Instance.selfcollision = true;
                }
            }
            Vector3 snake2headPosition = CoopSnakeController.Instance.snakeSegments[0].transform.position;
            for (int i = 1; i < SnakeController.Instance.snakeSegments.Count; i++)
            {
                if (Vector3.Distance(snake2headPosition, SnakeController.Instance.snakeSegments[i].transform.position) < 0.8f)
                {
                    CoopSnakeController.Instance.selfcollision = true;
                }
            }
        }
    }
}
