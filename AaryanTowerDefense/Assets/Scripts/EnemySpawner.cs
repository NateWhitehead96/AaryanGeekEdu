using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float gameTime; // count up all of the game time
    public int currentEnemy; // know what current enemy to spawn
    public float timer;
    public int wave; // wave counter
    public int enemiesRemaining; // how many enemies to spawn
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
        wave++; // increase wave
        enemiesRemaining += wave * 2; // every wave increase number of enemies by wave # x 2
        if(wave >= 3)
        {
            currentEnemy = 1; // start spawning a new enemy type
        }
        if(wave >= 6)
        {
            currentEnemy = 2;
        }
    }
}



