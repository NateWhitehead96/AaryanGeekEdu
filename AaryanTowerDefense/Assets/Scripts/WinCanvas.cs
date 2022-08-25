using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCanvas : MonoBehaviour
{
    // in our build settings, we know that main menu is level 0 and our game scene is level 1
    public void ReplayGame()
    {
        SceneManager.LoadScene(1); // load by build settings
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0); // load main menu
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
