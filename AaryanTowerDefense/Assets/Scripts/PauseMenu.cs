using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public void ResumeGame()
    {
        Time.timeScale = 1; // turn the time scale back to normal
        gameObject.SetActive(false); // hide the pause canvas
    }
}
