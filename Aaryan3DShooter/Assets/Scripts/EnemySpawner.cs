using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy; // what enemy we want to spawn
    public float leftBounds, rightBounds, upBounds, botBounds; // all of the bounds
    public int wave; // what wave we're on
    public int numberOfEnemies; // how many enemies we want to spawn
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfEnemies > 0) // we have more enemies to spawn than 0
        {
            float x = Random.Range(leftBounds, rightBounds); // find new x position
            float z = Random.Range(botBounds, upBounds); // find new z position
            transform.position = new Vector3(x, transform.position.y, z); // apply new position
            Instantiate(enemy, transform.position, transform.rotation); // spawn the enemy
            numberOfEnemies -= 1; // subtract 1 enemy
        }
    }
}
