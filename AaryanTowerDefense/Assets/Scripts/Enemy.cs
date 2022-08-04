using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Path path; // access to the path and all of its checkpoints
    public int currentPoint; // the current point enemy is moving towards
    public int health; // health lol
    public float speed; // how fast it moves
    public Slider healthBar; // access to the health bar
    // Start is called before the first frame update
    void Start()
    {
        path = FindObjectOfType<Path>(); // its going to find the path script on our path, and set it to this variable
        healthBar.maxValue = health; // set the max value of the slider to be whatever our health is
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health; // constantly update the health value
        // moveing enemy to the current checkpoint its going to, at its speed times time.deltaTime
        transform.position = Vector3.MoveTowards(transform.position, path.checkpoints[currentPoint].position, speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, path.checkpoints[currentPoint].position); // find distance
        if(distance <= 0.05f) // if we're at the current point, or at least very very close
        {
            currentPoint++; // increase current point by 1, so now our enemy moves to the next point
        }
        if(currentPoint >= path.checkpoints.Length)
        {
            FindObjectOfType<GameManager>().lives--; // lose a life when enemy hits the last checkpoint
            Destroy(gameObject); // when the enemy is at the last checkpoint, kill it
            // lose health or lives for player
        }
        if(health <= 0)
        {
            SoundEffectManager.instance.EnemyDie.Play();
            FindObjectOfType<GameManager>().gold += 5; // get 5 gold
            Destroy(gameObject);
        }
    }
}
