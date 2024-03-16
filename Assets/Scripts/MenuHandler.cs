using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
  public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSinglePlayer()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadCoOp()
    {
        SceneManager.LoadScene(2);
    }
}
