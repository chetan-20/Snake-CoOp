using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject LevelObject;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject ScoreUI;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TextMeshProUGUI FinalScore;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        UpdateScoreUI();
        OnEscapePressed();
    }

    private void UpdateScoreUI()
    {
        scoreUI.text="Score : " + SnakeController.Instance.score;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
        LevelObject.SetActive(false);
        ScoreUI.SetActive(false);
    }

    public void ResumeGame() 
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
        LevelObject.SetActive(true);
        ScoreUI.SetActive(true);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OnEscapePressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void OnGameOver()
    {
        Time.timeScale = 0f;
        LevelObject.SetActive(false);
        ScoreUI.SetActive(false);
        GameOverPanel.SetActive(true);
        FinalScore.text = "Final Score : " + SnakeController.Instance.score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
