using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // give us access to scene switching/loading

public class LoseScreen : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(0); // reload the game scene
    }
}
