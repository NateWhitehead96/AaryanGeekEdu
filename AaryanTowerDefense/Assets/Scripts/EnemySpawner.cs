using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float gameTime; // count up all of the game time
    public int currentEnemy; // know what current enemy to spawn
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 1) // how quick enemies spawn
        {
            Instantiate(enemy[currentEnemy], transform.position, transform.rotation); // spawn enemy
            timer = 0; // reset timer
        }
        timer += Time.deltaTime; // count timer up
        gameTime += Time.deltaTime; // count up game time
        if(gameTime >= 60)
        {
            currentEnemy++; // make the current enemy the next one
            if(currentEnemy >= enemy.Length) // if we've gotten to our last spawnable enemy
            {
                currentEnemy = enemy.Length; // then just set current enemy to the last enemy
            }
            gameTime = 0; // reset the game game time
        }
    }
}
