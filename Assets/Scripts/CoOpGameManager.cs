using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoOpGameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI snakescoreUI;
    [SerializeField] private TextMeshProUGUI coopsnakescoreUI;
    [SerializeField] private GameObject LevelObject;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject ScoreUIObject;
    [SerializeField] private GameObject GameOverUIObject;
    [SerializeField] internal TextMeshProUGUI WinText;
    [SerializeField] private GameObject PowerUpUI;
    public static CoOpGameManager Instance;

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
       snakescoreUI.text = "P1 Score : " + SnakeController.Instance.score;
       coopsnakescoreUI.text = "P2 Score : " + CoopSnakeController.Instance.score;
    }

    public void PauseGame()
    {

        Time.timeScale = 0f;
        PausePanel.SetActive(true);
        LevelObject.SetActive(false);
        ScoreUIObject.SetActive(false);
        PowerUpUI.SetActive(false);
    }

    public void ResumeGame()
    {
        SoundController.Instance.PlaySound(Sounds.ButtonClickSound);
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
        LevelObject.SetActive(true);
        ScoreUIObject.SetActive(true);
        PowerUpUI.SetActive(true);
    }

    public void LoadMenu()
    {
        SoundController.Instance.PlaySound(Sounds.ButtonClickSound);
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
        SoundController.Instance.PlaySound(Sounds.GameOverSound);
        Time.timeScale = 0f;
        LevelObject.SetActive(false);
        ScoreUIObject.SetActive(false);
        GameOverUIObject.SetActive(true);
        PowerUpUI.SetActive(false);
       // WinText.text = "Won";
    }

    public void RestartGame()
    {
        SoundController.Instance.PlaySound(Sounds.ButtonClickSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
