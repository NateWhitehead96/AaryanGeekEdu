using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // allows us to move to other scenes

public class MenuScript : MonoBehaviour
{
    public Slider volumeSlider; // access to the slider in the settings
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    // Start is called before the first frame update
    void Start()
    {
        SettingsMenu.SetActive(false); // start with settings hidden
    }

    // Update is called once per frame
    void Update()
    {
        SoundEffectManager.instance.volume = volumeSlider.value; // change the volume of our sound effects
    }

    public void PlayGame()
    {
        //SceneManager.LoadScene("SampleScene"); // open our play scene
        FindObjectOfType<TransitionScript>().MoveToScene(1); // open our play scene
    }

    public void OpenSettings()
    {
        SettingsMenu.SetActive(true); // show settings
        MainMenu.SetActive(false); // hide menu
    }

    public void ExitGame()
    {
        Application.Quit(); // this will only work when we build the game
    }

    public void ReturnToMainMenu()
    {
        SettingsMenu.SetActive(false); // hide settings
        MainMenu.SetActive(true); // show menu
    }
}
