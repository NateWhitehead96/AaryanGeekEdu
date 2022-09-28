using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // give access to ai stuff

public class AIEnemy : MonoBehaviour
{
    public NavMeshAgent agent; // thing that controls the AI
    public Transform player; // player will be the target of our AI

    public int health; // how much health does ai man have
    public int moneyDrop; // how much money the enemy gives when dies
    public int damage; // how much damage this guy deals
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform; // link player to the player in the scene
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position); // make the enemy move towards our player

        if(health <= 0)
        {
            Destroy(gameObject); // destroy the enemy if its health is 0
            FindObjectOfType<PlayerStats>().money += moneyDrop; // increase our money
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>()) // bullet collides with enemy
        {
            print("hit by bullet");
            health -= 1; // deal damage
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStats>().health -= damage;
        }
    }
}
