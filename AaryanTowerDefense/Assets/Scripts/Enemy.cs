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
    public Animator anim; // link to the animation stuff
    public bool dying; // to know if the enemy is dying
    public bool stunned; // to know when the enemy has been hit by lightning
    float timer; // help us unstun the enemy
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawner.enemiesAlive++; // increase the enemies alive number by 1
        anim = GetComponent<Animator>(); // link the game objects animator to our variable
        path = FindObjectOfType<Path>(); // its going to find the path script on our path, and set it to this variable
        healthBar.maxValue = health; // set the max value of the slider to be whatever our health is
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health; // constantly update the health value
        // moveing enemy to the current checkpoint its going to, at its speed times time.deltaTime
        if (stunned == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, path.checkpoints[currentPoint].position, speed * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, path.checkpoints[currentPoint].position); // find distance
            if (distance <= 0.05f) // if we're at the current point, or at least very very close
            {
                currentPoint++; // increase current point by 1, so now our enemy moves to the next point
            }
            if (currentPoint >= path.checkpoints.Length)
            {
                EnemySpawner.enemiesAlive--; // subtract here
                FindObjectOfType<GameManager>().lives--; // lose a life when enemy hits the last checkpoint
                Destroy(gameObject); // when the enemy is at the last checkpoint, kill it
                                     // lose health or lives for player
            }
        }
        if(stunned == true)
        {
            timer += Time.deltaTime; // start counting up
            if(timer >= 0.5f)
            {
                stunned = false;
                timer = 0;
            }
        }
        if(health <= 0 && dying == false)
        {
            EnemySpawner.enemiesAlive--; // subtract here
            StartCoroutine(EnemyDying());
        }
    }

    IEnumerator EnemyDying()
    {
        dying = true;
        SoundEffectManager.instance.EnemyDie.Play();
        FindObjectOfType<GameManager>().gold += 5; // get 5 gold
        anim.SetBool("dying", dying); // play the death animation
        GetComponent<BoxCollider2D>().enabled = false; // disable the collider
        speed = 0;
        yield return new WaitForSeconds(0.5f); // wait some time
        Destroy(gameObject); // destroy the enemy
    }
}
