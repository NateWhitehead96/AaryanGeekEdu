using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
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
            Instantiate(enemy, transform.position, transform.rotation); // spawn enemy
            timer = 0; // reset timer
        }
        timer += Time.deltaTime; // count timer up
    }
}
