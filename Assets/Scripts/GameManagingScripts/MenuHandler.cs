using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
  public void QuitGame()
    {
        SoundController.Instance.PlaySound(Sounds.ButtonClickSound);
        Application.Quit();
    }

    public void LoadSinglePlayer()
    {
        SoundController.Instance.PlaySound(Sounds.ButtonClickSound);
        SceneManager.LoadScene(1);
    }

    public void LoadCoOp()
    {
        SoundController.Instance.PlaySound(Sounds.ButtonClickSound);
        SceneManager.LoadScene(2);
    }
}
