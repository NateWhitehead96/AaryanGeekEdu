using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    public Animator anim; // animation controller
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // link the animator to this variable
    }

    public void MoveToScene(int levelToLoad) // help us move to a new scene & play transition
    {
        StartCoroutine(Fade(levelToLoad)); // pass the level to load into our coroutine
    }

    IEnumerator Fade(int level)
    {
        anim.SetBool("fade", true); // play the fade
        yield return new WaitForSeconds(2); // wait some time
        SceneManager.LoadScene(level); // load ze level
    }
}
