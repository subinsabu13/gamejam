using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        PauseMenu.GameIsPaused = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
