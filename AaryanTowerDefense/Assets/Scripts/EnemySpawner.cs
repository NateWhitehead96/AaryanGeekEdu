using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float gameTime; // count up all of the game time
    public int currentEnemy; // know what current enemy to spawn
    public float timer;
    public int wave; // wave counter
    public int enemiesRemaining; // how many enemies to spawn
    public static int enemiesAlive; // how many enemies are alive on screen
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 1 && enemiesRemaining > 0) // how quick enemies spawn
        {
            Instantiate(enemy[currentEnemy], transform.position, transform.rotation); // spawn enemy
            timer = 0; // reset timer
            enemiesRemaining--; // subtract 1
            if (enemiesRemaining == 0)
            {
                StartCoroutine(StartNextWave());
            }
        }
        timer += Time.deltaTime; // count timer up

        /* 
        gameTime += Time.deltaTime; // count up game time
        if(gameTime >= 60)
        {
            currentEnemy++; // make the current enemy the next one
            if(currentEnemy >= enemy.Length) // if we've gotten to our last spawnable enemy
            {
                currentEnemy = enemy.Length; // then just set current enemy to the last enemy
            }
            gameTime = 0; // reset the game game time
        */
    }

    IEnumerator StartNextWave()
    {
        yield return new WaitForSeconds(10); // waiting for some time
        SoundEffectManager.instance.NextWave.Play(); // play the next wave sound
        wave++; // increase wave
        enemiesRemaining += wave * 2; // every wave increase number of enemies by wave # x 2
        if(wave >= 5)
        {
            currentEnemy = 1; // start spawning a new enemy type
        }
        if(wave >= 10)
        {
            currentEnemy = 2;
        }
        if(wave >= 15)
        {
            currentEnemy = 3;
        }

        if(wave > 25) // when we go over our last wave, stop spawning enemies
        {
            enemiesRemaining = 0; // wont spawn any more
            if(enemiesAlive <= 0)
            {
                SceneManager.LoadScene(2); 
            }
        }
    }
}



