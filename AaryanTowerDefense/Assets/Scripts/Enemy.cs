using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Path path; // access to the path and all of its checkpoints
    public int currentPoint; // the current point enemy is moving towards
    public int health; // health lol
    public float speed; // how fast it moves
    // Start is called before the first frame update
    void Start()
    {
        path = FindObjectOfType<Path>(); // its going to find the path script on our path, and set it to this variable
    }

    // Update is called once per frame
    void Update()
    {
        // moveing enemy to the current checkpoint its going to, at its speed times time.deltaTime
        transform.position = Vector3.MoveTowards(transform.position, path.checkpoints[currentPoint].position, speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, path.checkpoints[currentPoint].position); // find distance
        if(distance <= 0.05f) // if we're at the current point, or at least very very close
        {
            currentPoint++; // increase current point by 1, so now our enemy moves to the next point
        }
        if(currentPoint >= path.checkpoints.Length)
        {
            Destroy(gameObject); // when the enemy is at the last checkpoint, kill it
            // lose health or lives for player
        }
    }
}
